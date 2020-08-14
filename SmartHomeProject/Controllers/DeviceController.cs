﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeProject.ConnectionManager;
using SmartHomeProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SmartHomeProject.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(ILogger<DeviceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult JarvisControl()
        {
            var pageModel = new ControlModel { DeviceModels = DatabaseManager.getDeviceModels() };
            return View(pageModel);
        }


        [HttpGet]
        public IActionResult DeviceFunctions()
        {
            var pageModel = new DeviceFunctionsModel { DeviceModels = DatabaseManager.getDeviceModels() };
            return View(pageModel);
        }

        [HttpPost]
        public IActionResult addDeviceFunction(int deviceID, string functionname, int functionpin, bool RGB)
        {
            var result = false;
            try
            {
                result = DatabaseManager.AddFunctionToDevice(deviceID, functionname, (byte)functionpin, RGB);
            }
            catch (Exception e)
            {
                result = false;
                Logger.Logger.logError(Logger.Logger.Category.DEVICE_CONTROLLER, e.Message, e);
            }

            var pageModel = new DeviceFunctionsModel
            {
                DeviceModels = DatabaseManager.getDeviceModels(),
                addedFunction = true,
                addedSuccess = result,
                deviceSelected = true,
                functionNameAdded = functionname,
                selectedDeviceID = deviceID
            };
            return View("DeviceFunctions", pageModel);
        }

        [HttpGet]
        public IActionResult ControlFunction(int functionID, string deviceName)
        {
            var pageModel = new ControlModel { DeviceModels = DatabaseManager.getDeviceModels() };
            var modelsD = new DeviceManageModel { DeviceModels = DatabaseManager.getDeviceModels() };


            for (var i = 0; i < modelsD.DeviceModels.Length; i++)
            {
                if (modelsD.DeviceModels[i].name == deviceName)
                {
                    for (var k = 0; k < modelsD.DeviceModels[i].DeviceFunctions.Count; k++)
                    {
                        if (modelsD.DeviceModels[i].DeviceFunctions[k].functionID == functionID)
                        {
                            //Hier müsste dann an den server geschickt werden und der state geändert werden umgehe das erstmal
                            modelsD.DeviceModels[i].DeviceFunctions[k].executeFunction();
                        }
                    }
                }
            }

            return RedirectToAction("JarvisControl", pageModel);
            //return View("JarvisControl", pageModel);
        }

        [HttpPost]
        public IActionResult EditDeviceSettings(string selectedDevice, string deviceNameNew, string deviceType,
            string deviceDescription, string deviceIP, string devicePort, string deviceLocation)
        {
            var result = DatabaseManager.UpdateDevice(selectedDevice, deviceNameNew, deviceType, deviceDescription,
                deviceIP, devicePort, deviceLocation);
            var pageModel = new DeviceEditModel
            {
                selectedDevice = deviceNameNew,
                DeviceModels = DatabaseManager.getDeviceModels(),
                deviceNameEdited = selectedDevice,
                editingFailed = !result
            };
            return View("EditDevice", pageModel);
        }

        [HttpGet]
        public IActionResult DeviceManage()
        {
            var pageModel = new DeviceManageModel { DeviceModels = DatabaseManager.getDeviceModels() };
            return View(pageModel);
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult EditDevice()
        {
            var pageModel = new DeviceEditModel { DeviceModels = DatabaseManager.getDeviceModels() };
            return View("EditDevice", pageModel);
        }

        [HttpPost]
        public IActionResult EditDevice(string model)
        {
            var pageModel = new DeviceEditModel
            { DeviceModels = DatabaseManager.getDeviceModels(), selectedDeviceName = model };
            return View("EditDevice", pageModel);
        }

        [HttpPost]
        public IActionResult AddNewSensor(int deviceIDSensor)
        {
            var rnd = new Random();
            const string python = "GPIO.setup(PIN[0], GPIO.IN)\r\nreturn GPIO.input(PIN[0])";
            var result = false;
            var sensorname = "New Sensor <" + rnd.Next(0, 9999) + ">";
            try
            {
                result = DatabaseManager.AddSensorToDevice(deviceIDSensor, sensorname, new byte[] { },
                    python);
            }
            catch (Exception e)
            {
                if (Logger.Logger.VERBOSE_LOG)
                {
                    Logger.Logger.logError(Logger.Logger.Category.DEVICE_FUNCTION, e.Message, e);
                }

                result = false;
            }

            var pageModel = new DeviceFunctionsModel
            {
                selectedDeviceID = deviceIDSensor,
                deviceSelected = true,
                DeviceModels = DatabaseManager.getDeviceModels(),
                sensorName = sensorname,
                sensorAdded = true,
                sensorAddSuccess = result
            };
            return View("DeviceFunctions", pageModel);
        }

        [HttpPost]
        public IActionResult EditSensor(int deviceIDSensor, int sensorOptions, string sensorname,
            string SensorGPIO_PINS,
            string SensorLocation, string content, string method)
        {
            try
            {
                Console.WriteLine("Werte: " + deviceIDSensor + " " + sensorOptions + " " + sensorname + " " +
                                  SensorGPIO_PINS + " " + SensorLocation + " " + content + " " + method);
                var result = false;
                if (method == "Delete")
                {
                    result = DatabaseManager.DeleteSensor(sensorOptions);
                }
                else
                {
                    var pins = new List<byte>();
                    if (!string.IsNullOrEmpty(SensorGPIO_PINS))
                    {
                        var split = SensorGPIO_PINS.Split(";");
                        for (var i = 0; i < split.Length; i++)
                        {
                            split[i] = split[i].Trim();
                            if (!string.IsNullOrEmpty(split[i]))
                            {
                                pins.Add(byte.Parse(split[i]));
                            }
                        }
                    }

                    result = DatabaseManager.UpdateSensor(sensorOptions, sensorname, pins.ToArray(), content,
                        SensorLocation);
                }

                if (result)
                {
                    var pageModel = new DeviceFunctionsModel
                    {
                        sensorEdited = true,
                        sensorEditetSuccess = result,
                        sensorName = sensorname,
                        deviceSelected = true,
                        selectedDeviceID = deviceIDSensor,
                        DeviceModels = DatabaseManager.getDeviceModels()
                    };
                    return View("DeviceFunctions", pageModel);
                }
                else
                {
                    var pageModel = new DeviceFunctionsModel
                    {
                        sensorEdited = true,
                        sensorEditetSuccess = result,
                        sensorName = DatabaseManager.getSensornameById(sensorOptions),
                        deviceSelected = true,
                        selectedDeviceID = deviceIDSensor,
                        DeviceModels = DatabaseManager.getDeviceModels()
                    };
                    return View("DeviceFunctions", pageModel);
                }
            }
            catch (Exception e)
            {
                if (Logger.Logger.VERBOSE_LOG)
                {
                    Logger.Logger.logError(Logger.Logger.Category.DEVICE_CONTROLLER, e.Message, e);
                }

                var pageModel = new DeviceFunctionsModel
                {
                    sensorEdited = true,
                    sensorEditetSuccess = false,
                    DeviceModels = DatabaseManager.getDeviceModels()
                };
                return View("DeviceFunctions", pageModel);
            }
        }

        [HttpPost]
        public ActionResult EditDeviceFunction(int deviceFunctions, string functionnameEdit, int pinEdit, string method,
            bool rgbEdit)
        {
            var editResult = false;
            var save = false;
            var delete = false;
            var deleteResult = false;
            if (method == "Save")
            {
                save = true;
                try
                {
                    editResult = DatabaseManager.UpdateDeviceFunction(deviceFunctions, functionnameEdit, (byte)pinEdit,
                        null, rgbEdit);
                }
                catch (Exception e)
                {
                    Logger.Logger.logError(Logger.Logger.Category.DEVICE_CONTROLLER, e.Message, e);
                    editResult = false;
                }
            }
            else if (method == "Delete")
            {
                delete = true;
                try
                {
                    deleteResult = DatabaseManager.DeleteDeviceFunction(deviceFunctions);
                }
                catch (Exception e)
                {
                    Logger.Logger.logError(Logger.Logger.Category.DEVICE_CONTROLLER, e.Message, e);
                    deleteResult = false;
                }
            }

            var pageModel = new DeviceFunctionsModel
            {
                DeviceModels = DatabaseManager.getDeviceModels(),
                functionEdited = save,
                functionEditSuccess = editResult,
                functionDelete = delete,
                functionDeleteSuccess = deleteResult,
                functionNameAdded = functionnameEdit
            };
            return View("DeviceFunctions", pageModel);
        }

        [HttpPost]
        public IActionResult DeleteDevice(string returnUrl, string model)
        {
            var result = DatabaseManager.DeleteDevice(model);
            var pageModel = new DeviceManageModel
            { deleteErrored = !result, deletedDeviceName = model, DeviceModels = DatabaseManager.getDeviceModels() };
            return View("DeviceManage", pageModel);
        }

        [HttpGet]
        public ActionResult AddDevice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDevice(string deviceName, string deviceType, string deviceDescription, string deviceIP,
            string devicePort, string deviceLocation)
        {
            var result = DatabaseManager.AddNewDevice(deviceName, deviceType, deviceDescription, deviceIP, devicePort,
                deviceLocation);
            var pageModel = new DeviceAddModel { successAdded = result, deviceName = deviceName };
            return View(pageModel);
        }
    }
}