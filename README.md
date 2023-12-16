# DMX to Display Bridge

## What is DMX2DB
DMX to Display Bridge is a simple peice of software designed to turn any old monitor into a IRGB DMX fixture connected over ArtNet.

## Getting Started

### Step 1: Installing
To get started using DMX2DB download the latest executable from the releases section. Currently, as we are using windows forms with the .NET framwork, only windows is supported. Alternatively you can build the executable from source using Visual Studio 2022.

### Step 2: Setup
After running the executable, you will be met with a menu that will prompt you to specify your Subnet, Universe, Starting Address, Network Adapter and Target Display. Once you have filled out this information the specified monitor will fill with the shade of colour currently being sent over DMX/Artnet.

### Step 3: Create
Open your chosen Lighting Control Software and configure it for Artnet (as of right now, we only support unicast so make sure your software supports it).

## Notes
- You cannot (as of yet) run two instances of the application on the same network adapter so make sure that you have either multiple computers or network adapters for more complex setups.
- If you leave the displays on for too long they may develop burn in (untested).
- This is a very experimental software and WILL have bugs.
- The Artnet integration used was https://github.com/cansik/ArtNet3DotNet.
