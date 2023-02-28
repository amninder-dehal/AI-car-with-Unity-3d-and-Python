import tensorflow as tf 
import numpy as np 
import keras
import socket
server = ('192.168.1.10', 4000)

s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

def network(input):
    input_layer = tf.keras.layers.Input(shape=(3,))
    hidden_layer_1 = tf.keras.layers.Dense(6, activation='relu')(input_layer)
    output_layer = tf.keras.layers.Dense(3, activation='softmax')(hidden_layer_1)
    model = tf.keras.models.Model(inputs=input_layer, outputs=output_layer)
        
    # model.set_weights(weight)
    model.compile(optimizer='adam', loss='categorical_crossentropy', metrics=['accuracy'])
    
    arr = np.array(model.predict(input))
    max_index = np.argmax(arr)

    # print(max_index)
    return max_index

# print(network([[1,0,0]]))
