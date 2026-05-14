# Story S1-01: Dice Engine & Oracle API

**Sprint:** 1
**Points:** 3
**Branch:** `feat/s1-01-dice-oracle`
**Status:** Ready

## User Story

As a solo player, I want to roll dice and consult the SoloDark oracle via API so that the game mechanics engine exists and I can build UI on top of it in a later sprint.

## Scope

API-only. No React, no auth, no database. Stateless endpoints backed by pure C# logic.

## Acceptance Criteria

### Dice Roller — `POST /api/dice/roll`

- [ ] Accepts standard NdX+M notation: `1d6`, `2d6+3`, `d20`, `1d100`
- [ ] Returns each individual die result in `[N]` bracket format
- [ ] Returns full show-math display string: `[5][6]+3=14`
- [ ] Advantage: rolls 2 dice, takes highest (`2d20` is NOT advantage — advantage means "roll twice, keep best")
- [ ] Disadvantage: rolls 2 dice, takes lowest
- [ ] If both advantage and disadvantage apply, they cancel (standard roll)
- [ ] d20 crits: natural 20 = `CRITICAL SUCCESS`, natural 1 = `CRITICAL FAILURE` (flag in response)
- [ ] d100 percentile convention: tens die (00, 10, 20...90) + ones die (0-9). 00+0 = 100. Range: 1-100.
  - Display: `[80]+[2]=82`
- [ ] Exploding dice (Grinder Mode flag): on max face, roll again and add, uncapped

### Oracle — `POST /api/oracle/ask`

- [ ] Accepts `odds` field: `unlikely`, `impossible`, `even`, `likely`, `certain`
- [ ] Rolls d20: `unlikely`/`impossible` = disadvantage, `even` = standard, `likely`/`certain` = advantage
- [ ] Result interpretation:
  - 1-9 = **No**
  - 10 = **Twist!** (auto-rolls Prompts table — deferred to S1-02; for now, flag `isTwist: true` in response)
  - 11-20 = **Yes**
  - Odd result (excluding nat 1) = adds "but..." complication flag
  - Nat 1 = **No** + `isCritical: true` (CRITICAL FAILURE)
  - Nat 20 = **Yes** + `isCritical: true` (CRITICAL SUCCESS)
- [ ] Returns full roll display: `d20=[17]` (or `2d20=[17,4] take highest=17` for advantage)
- [ ] Returns Lonelog-formatted line: `d: Oracle(Likely) d20=[17] -> Yes`

### Response Format

**Dice roll response:**
```json
{
  "notation": "2d6+3",
  "rolls": [5, 6],
  "modifier": 3,
  "total": 14,
  "display": "[5][6]+3=14",
  "isCritical": false,
  "criticalType": null
}
```

**Oracle response:**
```json
{
  "odds": "likely",
  "roll": 17,
  "rolls": [17, 4],
  "rollDisplay": "2d20=[17,4] take highest=17",
  "answer": "Yes",
  "hasComplication": false,
  "isTwist": false,
  "isCritical": false,
  "criticalType": null,
  "lonelogLine": "d: Oracle(Likely) 2d20=[17,4] take highest=17 -> Yes"
}
```

### Tests (xUnit)

- [ ] `DiceEngineTests`: standard roll, advantage, disadvantage, both-cancel, d100 convention, crit detection, exploding dice, modifier math
- [ ] `OracleEngineTests`: each odds type, Twist result (10), "but..." complication (odd non-1), nat 1 CRITICAL FAILURE, nat 20 CRITICAL SUCCESS, display string, Lonelog line
- [ ] `DiceControllerTests` and `OracleControllerTests`: happy path + invalid input returns 400

### Out of Scope (deferred)

- Prompts table (Twist integration) → S1-02
- Dungeon name generator → S1-02
- Character import → S1-03
- Session journal → Sprint 2+
- Oracle question counter (max 3 per situation) → Sprint 2+ (needs persistence)

## Project Structure to Add

```
src/SoliGavant.Api/
├── Controllers/
│   ├── DiceController.cs
│   └── OracleController.cs
├── Models/
│   ├── DiceRollRequest.cs
│   ├── DiceRollResponse.cs
│   ├── OracleRequest.cs
│   └── OracleResponse.cs
├── Services/
│   ├── IDiceEngine.cs
│   ├── DiceEngine.cs
│   ├── IOracleEngine.cs
│   └── OracleEngine.cs

src/SoliGavant.Tests/
├── DiceEngineTests.cs
└── OracleEngineTests.cs
```

## Tasks

- [ ] Delete `WeatherForecast.cs` and `WeatherForecastController.cs` (scaffold cleanup)
- [ ] Write `DiceEngine` + tests (TDD: tests first)
- [ ] Write `OracleEngine` + tests (TDD: tests first)
- [ ] Write `DiceController` with request validation
- [ ] Write `OracleController` with request validation
- [ ] Register services in `Program.cs`
- [ ] Smoke test via Swagger / `.http` file
- [ ] PR + CI green

## Lonelog Conventions (for Oracle output)

- Odds label in Lonelog: `Oracle(Likely)`, `Oracle(Even)`, `Oracle(Unlikely)`, etc.
- Advantage display: `2d20=[17,4] take highest=17`
- Disadvantage display: `2d20=[17,4] take lowest=4`
- Standard display: `d20=[17]`
- Arrow: `->` (resolution outcome)
