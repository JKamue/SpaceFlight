
<h1 align="center">
  <br>
  <a href="https://jkamue.de"><img src="https://jkamue.de/logos/logo_dark.png" alt="Markdownify" width="200"></a>
  <br>
  Space Flight Simulator
  <br>
</h1>

<h4 align="center">A small rocket simulator inspired by <a href="https://play.google.com/store/apps/details?id=com.StefMorojna.SpaceflightSimulator&hl=de" target="_blank">Spaceflight Simulator</a>.</h4>


<p align="center">
  <a href="#key-features">Key Features</a> •
  <a href="#how-to-use">How To Use</a> •
  <a href="#credits">Credits</a>
</p>

<h1 align="center">
<img src="https://jkamue.de/logos/spaceflight.pmg" width="1000">
</h1>

## Key Features

* Simulation as realistic as possible 
  - Simulatior calculates multiple forces:
    - Thrust
    - Gravity
    - Drag
  - Simulator calculates the weight of the rocket at each given time 
* Great controls
  - Easily change thrust or angle
  - (More complex controls like stage seperation will be added in future updates)
* Scaleable
  - Easily add your own rockets by adding them to the Data/Rockets folder
  - Easily add your own levels by copying it to the Data/Level folder
  
  
## How To Use

You can [download](https://github.com/JKamue/SpaceFlight/releases) the latest version of Space Flight Simulator.

At the moment only one Level is loaded by default, future updates will include a menu screen to select different levels and rockets.

You can already change the main level in the Data/Rockets folder or change the different statistics of the rockets.
Rockets are encoded in json:
```json
{
  "Model": "Atlas V",
  "Variant": "401",
  "Manufacturer": "ULA",
  "Names": [
    "AV-078",
    ...
  ],
  "Height": 56,
  "Width": 4,
  "Thrust": 3830000,
  "Weight": 330388,
  "FuelWeight": 304919,
  "BurnTime": 240,
  "DragProperties": {
    "CdUp": 0.25,
    "CdSide": 0.42,
    "AreaUp": 13.8544236,
    "AreaSide": 218.313
  },
  "ThrustAreas": [
    {
      "Start": {
        "IsEmpty": false,
        "X": 0.1,
        "Y": -28
      },
      "Stop": {
        "IsEmpty": false,
        "X": 1.5,
        "Y": -28
      }
    },
    ...
  ],
  "Sprite": [...]
}
```

## Credits

This software uses the following open source packages:

- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
- This readme is inspired by the [Markdownify](https://github.com/amitmerchant1990/electron-markdownify) readme

Special thanks:

- [PhilHawk03](https://github.com/PhilHawk03) for a near infinite knowledge of rocket science and a lot of motivation

<br><br>


> [JKamue.de](https://www.jkamue.de) &nbsp;&middot;&nbsp;
> Twitter [@JKamue_dev](https://twitter.com/JKamue_dev)
