
# # import socket

# # # Create a new socket object
# # server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# # # Bind the socket to a specific IP address and port
# # server_address = ('192.168.1.10', 5000)
# # server_socket.bind(server_address)

# # # Listen for incoming connections
# # server_socket.listen()

# # # Wait for a client to connect
# # print('Waiting for client connection...')
# # client_socket, client_address = server_socket.accept()
# # print(f'Client connected: {client_address}')

# # # Receive data from the client
# # while True:
# #     data = client_socket.recv(1024)
# #     if not data:
# #         break
# #     message = data.decode('utf-8')
# #     print(f'{message}')

# # # Close the client socket and server socket
# # print('Closing client connection...')
# # client_socket.close()
# # print('Closing server socket...')
# # server_socket.close()



# import socket
# import time
# import neural 
# host='192.168.1.10'
# port=4000
# s= socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
# s.bind((host,port))
# print('server started')
# server = ('192.168.1.10', 4000)
# i=0

# while True:
# # for c in range(5):
#     list=[]
#     i+=1
#     data , addr = s.recvfrom(1024)
#     if not data:
#         break
#     message= data.decode('utf-8')
#     if message != '0,0,0':

#         print(message)


# s.close()
import paho.mqtt.client as mqtt
import time 
# broker = "test.mosquitto.org"
broker= "mqtt.eclipseprojects.io"

# port = 1883
# topic = "M2MQTT_Unity/test"
topic="response"

client = mqtt.Client()
client.connect(broker)

client.subscribe(topic)


# def on_message(client, userdata, message):
    # print("Received message: ", str(message.payload.decode("utf-8")))
while True:
    client.publish("topic","0")
    time.sleep(2)
# client.on_message = on_message
# print("waiting for msg ")
# client.loop_forever()