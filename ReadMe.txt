Copyright (c) 2013, Pleora Technologies Inc., All rights reserved.

==============
ImageProcessing
==============

This sample shows how to use the PvStream class for image acquisition and processing using a third party buffer

1. Introduction

Using the PvStream class, this sample shows how to:
 * Connect to a device
 * Setup the stream
 * Retrieve images from the device
 * Use the Graphics Color Matrix to apply a contrast to the image.
 * Monitor statistics
 * Stop streaming


2. Pre-conditions

This sample assumes that:
 * you have a GigE Vision Device connected to a network adapter or a U3V device connected to a USB 3.0 interface.

3. Description

3.1 MainForm.cs

Shows how to use the PvStream class for image acquisition and processing. Please refer to the comments in the source code for information on the methods used in this sample.

3.2 ColorMatrix.cs

Builds a contrast matrix.