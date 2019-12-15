#!/usr/bin/env python
# coding: utf-8

# In[1]:


get_ipython().run_line_magic('mathplotlib', 'inline')


# In[8]:


from keras.datasets import mnist
import matplotlib.pyplot as plt
import matplotlib.image as mpimg
import numpy as np
import sys
import scipy.special
import scipy.ndimage
import scipy.signal
from random import *


# In[9]:


(x_train, y_train),(x_test,y_test) = mnist.load_data()


# In[42]:


n=10
#print(y_train[n])
plt.imshow((255-x_test[n])/255, cmap = "gray")
print(test(n).argmax())


# In[111]:


def image_to_feature_vector(image, size=(28, 28)):
    return cv2.resize(image, size)


# In[112]:


image = mpimg.imread(r"C:\Users\annn\Desktop\Education\Unity\image.png")
image1 = image_to_feature_vector(image)
query_vec = np.array(1-image1).reshape(784)
plt.imshow(image, cmap="gray")
myNN.query(query_vec).argmax()


# In[104]:


class MyNN:
    def __init__(self, rate, inputs, hiddens, outputs):
        self.i_count=inputs+1
        self.h_count=hiddens
        self.o_count=outputs
        #Заполняем массивы весов рандомом
        self.w_ih = np.random.normal(0.0, pow(self.h_count, -0.5),(self.h_count, self.i_count))
        self.w_ho = np.random.normal(0.0, pow(self.o_count, -0.5),(self.o_count, self.h_count))
        #learning rate and sigmoid
        self.ir = rate
        self.activation_function = lambda x: scipy.special.expit(x)
        
    def train(self, inputs_list, targets_list):
        inputs_list = np.concatenate((inputs_list,[1]), axis = 0)
        #вектор-столбцы входных данных и правильных ответов
        inputs = np.array(inputs_list, ndmin=2).T
        targets = np.array(targets_list, ndmin=2).T
        #direct disappear
        hid_results = self.activation_function(np.dot(self.w_ih, inputs))
        out_results = self.activation_function(np.dot(self.w_ho, hid_results))
        #output errors
        out_errors = (targets - out_results)
        #errors of hidden layer
        hid_errors = np.dot(self.w_ho.T, out_errors)
        #corrections for weights hidden - output
        self.w_ho += self.ir * np.dot(out_errors*out_results*(1.0-out_results),np.transpose(hid_results))
        #corrections for weights hidden - put
        self.w_ih += self.ir * np.dot(hid_errors*hid_results*(1.0-hid_results),np.transpose(inputs))
    def query(self, inputs_list):
        inputs_list= np.concatenate((inputs_list,[1]), axis = 0)
        #vector-column input data
        inputs = np.array(inputs_list, ndmin=2).T
        #direct disappear
        hid_results = self.activation_function(np.dot(self.w_ih, inputs))
        out_results = self.activation_function(np.dot(self.w_ho, hid_results))
        return out_results
    
    def set_ir(self, rate):
        self.ir = rate
        
        


# In[27]:


myNN = MyNN(0.1, 784, 100, 10)


# In[28]:


def train(n):
    target = np.zeros(10)
    target[y_train[n]] = 1
    query = np.array(x_train[n]/255).reshape(784)
    myNN.train(query, target)


# In[79]:


def trainR(n):
    target = np.zeros(10)
    rot = random()*30-15
    imageR = scipy.ndimage.rotate(x_train[n]/255,rot,cval=0,reshape = False)
    query = np.array(imageR).reshape(784)
    myNN.train(query, target)


# In[50]:


def test(n):
    query = np.array(x_test[n]/255).reshape(784)
    return myNN.query(query)
    


# In[45]:


def test_t(n):
    query = np.array(x_train[n]/255).reshape(784)
    return myNN.query(query)


# In[85]:


def epoh_train():
    myNN.set_ir(0.001)
    x_train_len = len(x_train)
    for n in range(x_train_len):
        trainR(n)
        if (n%100==0):
            sys.stdout.write("Row: %s\r" % n)
            sys.stdout.flush()


# In[86]:


epoh_train()


# In[59]:


def epoch_test_t():       
    x_test_len = len(x_train)
    precision=0
    for n in range(x_test_len):
        ans = test_t(n)
        if (ans.argmax()==y_train[n]):
            precision+=1
    return precision/(n+1)


# In[60]:


def epoch_test():       
    x_test_len = len(x_test)
    precision=0
    for n in range(x_test_len):
        ans = test(n)
        if (ans.argmax()==y_test[n]):
            precision+=1
    return precision/(n+1)


# In[77]:


def epoch_test_draw():       
    x_test_len = len(x_test)
    precision=0
    for n in range(x_test_len):
        ans = test(n)
        if (ans.argmax()==y_test[n]):
            precision+=1
        else:
            plt.imshow((255-x_test[n])/255, cmap = "gray")
            plt.pause(0.1)
            print('NN: ' + str(ans.argmax())+': '+str(ans.max()))
    return x_test_len-precision


# In[87]:


print(epoch_test())
print(epoch_test_t())


# In[78]:


epoch_test_draw()


# In[88]:


import keras
from keras.datasets import mnist
from keras.models import Sequential
from keras.layers import Dense
from keras.utils import np_utils


# In[100]:


model = Sequential()

# add layers of net
model.add(Dense(100, input_dim=784,activation="sigmoid",kernel_initializer="random_normal", use_bias=True))
model.add(Dense(10,activation="sigmoid",kernel_initializer="random_normal", use_bias=False))
sgd = keras.optimizers.SGD(lr=0.01,momentum=0.0,decay=0.0,nesterov=False)
model.compile(loss="categorical_crossentropy",optimizer=sgd,metrics=["accuracy"])
print(model.summary())


# In[101]:


X_train = x_train.reshape(60000,784)
Y_train = np.zeros((len(y_train),10))
for n in range(len(y_train)):
    Y_train[n,y_train[n]]=1
model.fit(x=X_train, y=Y_train, batch_size=100,epochs=10,verbose=1)


# In[ ]:


X_test = x_test.reshape(60000,784)
Y_test = np.zeros((len(y_test),10))
evaluate(x=X_test,y=Y_test,batch_size=None,)

