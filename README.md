# UniUSBSQMServer

This application provides users of a USB version of the Unihedron Sky Quality Meter to share the data with multiple clients that support the device over TCP. This means that with a single device, multiple telescope imaging setups can access the data simultaneously.

Applications such as Astrophotograpjhy Tool (APT), Nighttime Imaging 'N' Astronomy (N.I.N.A.) can communicate with this application over TCP to obtain the data from the device.

UniUSBSQMServer will poll the USB device on a defined interval and retain the latest data in memory and serve this data to the client application.

The application supports the 'ix', 'rx' and 'ux' messages of the Unihedron protocol, and logs/trends the following data parameters
 - Raw magnitude/arc second<sup>2</sup>
 - Averaged magnitude/arc second<sup>2</sup>
 - Temperature
 - Naked Eye Limiting Magnitude (calculated)

![UniUSBSQMServer](https://user-images.githubusercontent.com/4674288/159138973-76b8982f-e9a1-4622-8704-303bc07a9c03.PNG)
