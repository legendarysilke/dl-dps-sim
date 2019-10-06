# dl-dps-sim
DPS simulation engine for Dragalia Lost with GUI. A work in progress.

## What's implemented
- Sword frame data
- Euden's skill frame data
- Defense debuffs
- A subset of dragons and their stats and abilities
- A subset of commonly used wyrmprints, their stats, and abilities
- The general damage formula
- Simple adjustable team DPS implemented as constant tick damage
- Strength, Skill Damage, Critical Rate, and Skill Haste co-abilities
- Sliders to adjust permanent facility levels
  - Permanent facility means things like dojos, altars, and slime statues.
- Run count
- Proper overdrive and break state simulation with modifiers on defense.

## What needs work
- Accurate frame data for sword combos that are not C3FS, C4FS, C5FS, and plain C5
- Possible rounding errors
- Performance (this simulator is very slow to run for accurate results)
  - Multithreading will improve this as each simulation instance can be considered as self-contained
- Split out data for adventurer/dragon/wyrmprint to outside the main code for maintenance

## What's not implemented
- Other weapon classes and adventurers
- Other weapons within the Sword class
- Combo counters
  - Flurry X passives
- Strength buffs in-combat
- Afflictions
- Bleeding damage
- Punishers and killer state
  - As neither afflictions nor bleeding is implemented, most punishers do not operate.
  - Overdrive and Broken Punisher will likely be implemented first, followed by others.
- Dragon form
- The Dragon Claws ability
  - As dragon form is not simulated at all for the time being, in the interests of accuracy (due to highly varying amounts of dragon gauge prep and gain rate in quests), Dragon Claws is not included in the simulation numbers.
- Dracolith
  - As dragon form is not simulated at all for the time being, these will remain unimplemented.
- Dragon Haste, and Shapeshifting Boost co-abilities
  - As dragon form is not simulated at all for the time being, these will remain unimplemented.
- Detailed team DPS implemented as separate adventurers
- Limited-time facilities (e.g. Sweet Retreat from Halloween)
  - Not all players have access to all of them, and they will be implemented later.
- Fafnir statues
- Helper usage
- Attack uptime
  - This will inflate DPS numbers against enemies that aren't a DPS sandbag or Fafnir Roy III (which is a glorified DPS sandbag)
  - Expect actual DPS numbers against a moving enemy to be around half or lower.
- Percentage-based overdrive and break state
  - This causes a lot more assumptions that I'm not personally comfortable with, as quest content have the time spent in OD and Break vary greatly, with the advent of bosses that have pseudo-permanent OD states (e.g. Chronos Nyx) and both very short (e.g. Chronos Nyx) and permanent (Veronica) break states.

## On the default setup
Resounding Rendition, Jewels of the Sun, and Konohana Sakuya are set as default equipment for Euden.
- This resembles a best setup for Euden under general purposes, without factoring in dragon form at all, and without using limited-time wyrmprints.
- It is possible to improve on DPS with United by One Vision, Seaside Princess, or Evening of Luxury, but they are not the default for the following reasons:
  - United by One Vision is a limited-time wyrmprint and may not be easily available for the time being, after the first anniversary passes.
  - Seaside Princess and Evening of Luxury depend on the user being on Full HP, which is only reasonable in the Mercurial Gauntlet for Flame-attuned adventurers.
  
It is possible to trade off DPS for oDPS by switching out Konohana Sakuya for a Strength-boosting dragon such as Cerberus or Agni, as well as replacing the secondary wyrmprint with something that increases Force Damage.
