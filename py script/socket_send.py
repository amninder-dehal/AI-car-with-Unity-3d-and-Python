import paho.mqtt.client as mqtt
import pyautogui
import graph
import time 
# broker = "broker.hivemq.com"
broker= "mqtt.eclipseprojects.io"
port = 1883
topic = "testtopic1"

client = mqtt.Client()
client.connect(broker,port)
client.subscribe(topic)

def on_message(client, userdata, message):
    msg=  str(message.payload.decode("utf-8"))
    print("Received message: ",msg)

    if msg== "0":
        pyautogui.keyDown('up') 
        time.sleep(.2) 
        pyautogui.keyUp('up')
        client.publish("testtopic",str("send"))

    if msg== "2":
        pyautogui.keyDown('right') 
        pyautogui.keyDown('up')
        time.sleep(1) 
        pyautogui.keyUp('right')
        pyautogui.keyUp('up')
        client.publish("testtopic",str("send"))

    if msg== "1":
        pyautogui.keyDown('left')
        pyautogui.keyDown('up') 
        time.sleep(1) 
        pyautogui.keyUp('left')
        pyautogui.keyUp('up')
        client.publish("testtopic",str("send"))

    if msg == "r":
        pyautogui.press("r")
        client.publish("testtopic",str("send"))

    # if len(msg)>1:
    #     a, b = msg.split(",")

    #     graph.graph(a,b)

client.on_message = on_message
print("waiting for msg ")
client.loop_forever()

