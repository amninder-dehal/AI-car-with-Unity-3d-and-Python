

import matplotlib.pyplot as plt
import random

def generate_random_number():
    return random.randint(0, 100)

x_values = [0]
y_values = [0]


def graph(x,y):
	x_values.append(x)
	y_values.append(y)
	plt.xlabel('Generation')
	plt.ylabel('Fitness')
	plt.clf()  
	plt.plot(x_values, y_values)
	plt.show(block=False)
	plt.pause(.1)

# graph(2,8)

