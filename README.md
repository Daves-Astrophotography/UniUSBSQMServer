# UniUSBSQMServer

This application came about as a result of the ever growing astrophotography hobby. Starting off with one telescope setup, and having the USB device connected to that imaging setup, then adding a second imaging setup/telescope. I was looking for a way to share the data with both of the imaging setups without the need to replace existing working hardware.

This application provides users of a USB version of the Unihedron Sky Quality Meter to share the data with multiple clients that support the device over TCP. This means that with a single device, multiple telescope imaging setups can access the data simultaneously.

Applications such as Astrophotography Tool (APT), Nighttime Imaging 'N' Astronomy (N.I.N.A.) can communicate with this application over TCP to obtain the data from the device.

UniUSBSQMServer will poll the USB device on a defined interval and retain the latest data in memory and serve this data to the client application.

The application supports the 'ix', 'rx' and 'ux' messages of the Unihedron protocol, and logs/trends the following data parameters
 - Raw magnitude/arc second<sup>2</sup>
 - Averaged magnitude/arc second<sup>2</sup>
 - Temperature
 - Naked Eye Limiting Magnitude (calculated)

![UniUSBSQMServer](https://user-images.githubusercontent.com/4674288/159138973-76b8982f-e9a1-4622-8704-303bc07a9c03.PNG)


# For more information and features, visit the [wiki pages](https://github.com/Daves-Astrophotography/UniUSBSQMServer/wiki).
