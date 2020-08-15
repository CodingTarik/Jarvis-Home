import socket
import RPi.GPIO as GPIO

#/// SendSensor message ==>    Sensor:Port:Python-Code       (Sensor is a const)
#/// SendPin message ==>       Operation:Pin:Port            (Operation can be for instance Switch or Status)
#/// SendColor message ==>     SetColor:RGBA:Pin:Port        (SetColor is a const) (Split RGBA values with a semicolon e.g. 123;234;100;0.5)

def waitForMessage():
    s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    s.bind(("0.0.0.0",333))
    s.listen(5)
    while True:
        try:
            clientsocket, address = s.accept()
            msg = clientsocket.recv(1024).decode()  
            # Split max 2 times. Why? If we send python code the code should not be "damaged"
            # Split another time in the specific methods if you want to have more than three parameters
            msgsplit = msg.split(":", 2)
            print(msgsplit)
            s.close
            se = socket.socket(socket.AF_INET,socket.SOCK_STREAM)       
            if msgsplit[0] == "Switch":
                se.connect((address[0],int(msgsplit[2])))
                switchGPIOState(int(msgsplit[1]))         
                state = getGPIOState(int(msgsplit[1]))
                se.send(str.encode(state))
            elif msgsplit[0] == "Status":
                se.connect((address[0],int(msgsplit[2])))            
                state = str.encode(getGPIOState(int(msgsplit[1])))
                print(getGPIOState(int(msgsplit[1])))
                se.send(state)
            elif msgsplit[0] == "SetColor":             
                # because SetColor has more than 2 ':' you have to split the last part another time 
                msgsplit2 = msgsplit[2].split(":")
                print("Change RGBA to: " + msgsplit[1])
                ColorChange(msgsplit[1], msgsplit2[0])
                se.connect((address[0],int(msgsplit2[1])))
                se.send(str.encode(str("SUCCESS")))
            elif msgsplit[0] == "Sensor":
                se.connect((address[0],int(msgsplit[1])))  
                python = msgsplit[2]+"global execSensorValue; execSensorValue = sensorValue()"
                print("Execute:\r\n" + python)
                global execSensorValue
                execSensorValue = "ERROR:PYTHON ERROR"
                try:
                    exec(python) 
                except Exception as e:
                    execSensorValue = "ERROR:"+str(e)          
                else:
                    execSensorValue = "SUCCESS:"+str(execSensorValue)
                print("Result: " + str(execSensorValue))
                se.send(str.encode(str(execSensorValue)))
            else:
                se.connect((address[0],int(msgsplit[2]))) 
                se.send(str.encode("Layer-8-Error"))
                se.close()
        except Exception as e:
             print("ERROR: " + str(e))
             
def getGPIOState(gpioToCheck):
    GPIO.setup(gpioToCheck, GPIO.OUT)
    if GPIO.input(gpioToCheck) == True:
        return "1"
    else:
        return "0"
        print(GPIO.input(gpioToCheck))

# ColorInfo will be passed as RED;GREEN;BLUE;ALPHA       
def ColorChange(ColorInfo, Pin):
    print("This is the place where your color code takes place")
    print(ColorInfo)
    

def switchGPIOState(toSwitch):
    GPIO.setup(toSwitch, GPIO.OUT)
    if getGPIOState(toSwitch) == "1":
        GPIO.output(toSwitch, GPIO.LOW)
    else:
        GPIO.output(toSwitch, GPIO.HIGH)
  
GPIO.setmode(GPIO.BCM)   
waitForMessage()
