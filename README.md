<p align="center"><img src="res/OSFR.png"></p>

<p align="center">
    <a href="https://github.com/OpenFreeRealms/OpenFreeRealms/releases"><img src="https://img.shields.io/github/v/release/OpenFreeRealms/OpenFreeRealms?style=for-the-badge"></a>
    <a href="https://discord.gg/GD5vDXr9Zm"><img src="https://img.shields.io/badge/chat-on%20discord-7289da.svg?logo=discord&style=for-the-badge" alt="Discord"></a>
    <img src="https://img.shields.io/github/downloads/OpenFreeRealms/OpenFreeRealms/total?style=for-the-badge">
    
</p>

<p align="center">
Open Source Free Realms is a reversed engineered walking emulator for a now sunset game called Free Realms!
</p>

# Installation
 - Download XAMPP, This will allow you start up a local server for you to run around in. : https://www.apachefriends.org/

 - Download the new OSFR server from the releases tab: https://github.com/OpenFreeRealms/OpenFreeRealms/releases/tag/v1.0

 - After installing XAMPP and OSFR navigate to "C:/xampp/htdocs" and drop the "OSFR" folder inside. This is already preset for future proofing other players.

 - Make sure to startup XAMPP by clicking start on the "Apache" line.

 - Open the "OSFR Server" folder, start up "OFRServer" (Optionally you can create a shortcut for it), Accept all firewall rules that pop-up.

 - Open the "OSFR Client" folder, locate "FreeRealms.bat" and start it up (Optionally you can create a shortcut for it).

 - Enjoy walking around!

# Customization
You can freely customize your character within the PacketSendSelfToClient.json and ClientItemDefinitions.json
These 2 documents are half documented so feel free to explore yourself or ask on the discord.

# Tasks
- [x] Fix Disconnects with the current library
- [ ] [Revamp Server Module](https://github.com/OpenFreeRealms/OpenFreeRealms/issues/3)
- [ ] Continue mapping SendSelf and ItemDefinitions

This project has no affiliation with Daybreak Games. All rights and intellectual property belong to them.

This is a standalone project that allows anyone to help. Our main goal is to get a working stable singleplayer emulator out so everyone can enjoy Sacred Grove again.
