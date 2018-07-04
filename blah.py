from kivy.app import App
from kivy.uix.floatlayout import FloatLayout
from kivy.factory import Factory
from kivy.properties import ObjectProperty
from kivy.uix.popup import Popup
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.textinput import TextInput
from functools import partial

from kivy.base import runTouchApp
from kivy.uix.spinner import Spinner


import cv2
import numpy as np
import os

str_path=""
str_name=""
h=0.0
l=0.0
b=0.0
y=0
floor_images=[]


class LoadDialog(FloatLayout):
    load = ObjectProperty(None)
    cancel = ObjectProperty(None)

class LoadDialogNext(FloatLayout):
    loadnext = ObjectProperty(None)
    cancel = ObjectProperty(None)


class Root(FloatLayout):

    hgt = ObjectProperty(None)
    len = ObjectProperty(None)
    bre = ObjectProperty(None)
    plus = ObjectProperty(None)
    minus = ObjectProperty(None)
    floor = ObjectProperty(None)
    loadfile = ObjectProperty(None)

    def add(self):
        f=int(self.floor.text)
        if(f>=0):
         f=f+1
         self.floor.text=str(f)

    def subt(self):
        f=int(self.floor.text)
        if(f>0):
         f=f-1
         self.floor.text=str(f)



    def dismiss_popup(self):
        self._popup.dismiss()

    def show_load(self):

        global x
        x=int(self.floor.text)
        if(x==0):
            return
        if(x==1):
            content = LoadDialog(load=self.load, cancel=self.dismiss_popup)
            self._popup = Popup(title="Load file", content=content,
                            size_hint=(0.9, 0.9))
            self._popup.open()

        if(x>1):
            content = LoadDialogNext(loadnext=self.loadnext, cancel=self.dismiss_popup)
            self._popup = Popup(title="Load file", content=content,
                            size_hint=(0.9, 0.9))
            self._popup.open()
            x=x-1

    def loadnext(self, path, filename):
        global y
        global floor_images
        floor_images.append(str(filename))
        print(filename)
        print(floor_images[y])

        y=y+1
        self.dismiss_popup()


        global x
        if( x>1):
          content = LoadDialogNext(loadnext=self.loadnext, cancel=self.dismiss_popup)
          self._popup = Popup(title="Load file", content=content,
                        size_hint=(0.9, 0.9))
          self._popup.open()

        if(x==1):
           content = LoadDialog(load=self.load, cancel=self.dismiss_popup)
           self._popup = Popup(title="Load file", content=content,
                           size_hint=(0.9, 0.9))
           self._popup.open()
        x=x-1




    def load(self, path, filename):
        global y
        global floor_images
        floor_images.append(str(filename))
        print(floor_images[y])
        y=y+1
        self.dismiss_popup()

    def sub(self):
        global h
        global b
        global l
        h=float(self.hgt.text)
        b=float(self.bre.text)
        l=float(self.len.text)
        global floor_images
        print(floor_images)
        print(h,b,l)

class Editor(App):
    pass


Factory.register('Root', cls=Root)
Factory.register('LoadDialog', cls=LoadDialog)
Factory.register('LoadDialogNext', cls=LoadDialogNext)


if __name__ == '__main__':
    Editor().run()
