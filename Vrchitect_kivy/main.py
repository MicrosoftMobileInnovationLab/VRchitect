from kivy.app import App
from kivy.uix.floatlayout import FloatLayout
from kivy.factory import Factory
from kivy.properties import ObjectProperty
from kivy.uix.popup import Popup
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.textinput import TextInput
import cv2
import numpy as np
import os

str_path=""
str_name=""
h=0.0
l=0.0
b=0.0

class LoadDialog(FloatLayout):
    load = ObjectProperty(None)
    cancel = ObjectProperty(None)


class Root(FloatLayout):

    hgt = ObjectProperty(None)
    len = ObjectProperty(None)
    bre = ObjectProperty(None)
    loadfile = ObjectProperty(None)
    #text_input = ObjectProperty(None)

    def dismiss_popup(self):
        self._popup.dismiss()

    def show_load(self):
        content = LoadDialog(load=self.load, cancel=self.dismiss_popup)
        self._popup = Popup(title="Load file", content=content,
                            size_hint=(0.9, 0.9))
        self._popup.open()

    def load(self, path, filename):
        #file_path=os.path.join(path,filename[0])

        str_path=str(filename[0])
        print(str_path)
        img=cv2.imread(str_path)
        self.dismiss_popup()

    def sub(self):
        h=float(self.hgt.text)
        b=float(self.bre.text)
        l=float(self.len.text)
        print(h,b,l)

class Editor(App):
    pass


Factory.register('Root', cls=Root)
Factory.register('LoadDialog', cls=LoadDialog)

if __name__ == '__main__':
    Editor().run()
