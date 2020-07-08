import socket
# import GPIO STUF

def sendMessage(clientsocket, data):
    clientsocket.send(data)
    

def waitForMessage():
    s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    s.bind((str(ip),int(port)))
    s.listen(5)
    print(port,ip)
    while True:
        clientsocket, address = s.accept()
        msg = clientsocket.recv(1024)
        msgsplit = str(msg).split("'")
        
        
def returnGPIOState(gpioToCheck):
    #do the GPIO STUF
    print("LOLOLO")

def startCheck():
    f = open("config.txt","r")
    lines = f.readlines()
    
    if  lines[3].replace("\n","") == "FirstStart:True":
        print(lines[3])
        print("First Start Config Client")
        print("Geben sie die IP ihres Server ein: ", end='')
        ip = input()
        print("Geben sie den port ihres Server an(Für standart port 0): ", end='')
        port = input()
    else:
        splited = lines[5].replace("\n","").split(":")
        port = splited[1]
        splited = lines[4].replace("\n","").split(":")
        ip = splited[1]
        print("Loading from config")   
        print(port)
        return ip,port

'''
gpio = ["low"]
i = 1
while i < 10:
    gpio.append("low")       
    i = i+1
    '''
ip,port = startCheck()
splited = ip.split(" ")
ip = splited[0]

waitForMessage()
