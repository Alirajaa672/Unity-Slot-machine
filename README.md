# Unity Slot Machine

## Project Overview

A 2D slot machine game developed in Unity featuring animated reels, betting mechanics, win detection, sound effects, statistics tracking, and WebGL deployment.

## Gameplay Features

* 3 animated reels
* Adjustable betting system
* Balance management
* Winning combinations
* Jackpot system
* Sound effects
* Paytable panel
* Statistics tracking
* DOTween reel animations
* Credits panel

## Controls

* Spin Button: Spin the reels
* * Button: Increase bet
* * Button: Decrease bet
* Paytable Button: View payouts
* Close Button: Hide panels

## Win Conditions

Three matching symbols result in a win.

### Jackpot

Three Seven symbols award the jackpot prize.

## Payout Table

| Symbol | Reward |
| ------ | ------ |
| Seven  | 500    |
| Bell   | 50     |
| Cherry | 25     |
| Bar    | 10     |

## Architecture Overview

### Managers

* RNGManager
* BalanceManager
* AudioManager
* UIManager

### Core

* SlotMachine

### Reel System

* Reel
* ReelSymbol

## Folder Structure

Assets/
Scripts/
Core/
Managers/
Reel/
UI/
Sounds/
Sprites/

## How to Run

1. Open project in Unity 6.
2. Open SampleScene.
3. Press Play.

## How to Build

1. Open Build Profiles.
2. Select Web.
3. Click Build.

## Author

M. Ali
