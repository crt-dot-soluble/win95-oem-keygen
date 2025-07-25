# Windows 95 OEM License Key Specification (Educational Reference)

> **⚠️ For historical and educational purposes only. Windows 95 is discontinued and unsupported.**

---

## 📑 Table of Contents

1. [🔍 Overview](#overview)
2. [🔑 Key Format](#key-format)
3. [📅 Segment 1 – Date Code](#segment-1--date-code)
4. [🛠️ Segment 2 – Literal "OEM"](#segment-2--literal-oem)
5. [🔒 Segment 3 – Validation Segment](#segment-3--validation-segment)
6. [📝 Segment 4 – Free-form Suffix](#segment-4--free-form-suffix)
7. [💡 Clarifications & Notes](#clarifications--notes)
8. [📌 Example Valid Key](#example-valid-key)
9. [✅ Quick Validation Checklist](#quick-validation-checklist)
10. [📚 References](#references)

---

## 🔍 Overview

This document defines the structure and validation rules for Windows 95 OEM license keys, purely for educational and archival purposes. It clarifies common misconceptions about padding, leap-year logic, and checksum behavior.

---

## 🔑 Key Format

```
AAAAA-OEM-BBBBBBB-CCCCC
```

- **AAAAA** – Date Code (5 digits)
- **OEM** – Fixed literal
- **BBBBBBB** – Validation Segment (7 digits)
- **CCCCC** – Free-form suffix (5 digits)

---

## 📅 Segment 1 – Date Code

**Anchor:** `#segment-1--date-code`

- **Format:** `DDDYY` (5 digits)
  - `DDD`: Julian day of year (001–366)
  - `YY`: Year (95–02)
- **Constraints:**
  - `DDD` ∈ [001, 366], no leap-year enforcement
  - `YY` ∈ [95, 02]

---

## 🛠️ Segment 2 – Literal "OEM"

**Anchor:** `#segment-2--literal-oem`

- Must appear exactly as `OEM` (uppercase), surrounded by hyphens.
- Distinguishes OEM installer keys; required for validation.

---

## 🔒 Segment 3 – Validation Segment

**Anchor:** `#segment-3--validation-segment`

- **Format:** 7 numeric digits (`BBBBBBB`)
- **Rules:**
  1. **First digit** must be **0**.
  2. **Checksum:** Sum of all 7 digits **mod 7 = 0**.
  3. **Last digit** **must not** be **0**, **8**, or **9**.

---

## 📝 Segment 4 – Free-form Suffix

**Anchor:** `#segment-4--free-form-suffix`

- **Format:** 5 numeric digits (`CCCCC`)
- **Behavior:** Ignored by installer; can be any value.

---

## 💡 Clarifications & Notes

1. **No two-zero padding requirement**
   - Only the **first** digit of the validation segment must be `0`.
   - Additional leading zeroes are **allowed**, but **not required**.

2. **No leap-year logic**
   - The installer accepts any `DDD` up to **366**, regardless of `YY`.
   - There is **no check** for valid dates in non-leap years.

3. **Last-digit rule is arbitrary**
   - The ban on ending with `0`, `8`, or `9` is an **extra** check, independent of the modulo logic.

---

## 📌 Example Valid Key

```
19296-OEM-0000007-12345
```

- `19296`: Julian day 192 + year 1996.
- `0000007`: Starts with 0; sum = 7 → 7 % 7 = 0; ends in 7.
- `12345`: Arbitrary suffix.

---

## ✅ Quick Validation Checklist

- [ ] **AAAAA**: 5 digits; `DDD` ∈ [001–366]; `YY` ∈ [95–03]
- [ ] Contains literal `-OEM-` (case-sensitive)
- [ ] **BBBBBBB**: 7 digits; first = 0; sum % 7 = 0; last ∉ {0, 8, 9}
- [ ] **CCCCC**: any 5 numeric digits

---

> ⚠️ **Disclaimer:** Use this information responsibly. Do **not** circumvent software licensing.
