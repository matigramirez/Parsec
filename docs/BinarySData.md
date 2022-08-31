## EP8 BinarySData Info
### KISA SEED Header
On some files the KISA SEED Header was slightly modified. Originally it was:
```cpp
struct KSHeader {
 char signature[40];
 uint32_t checksum;
 uint32_t realSize;
 char padding[16];
}
```

New one is:
```cpp
struct KSHeader {
 char signature[40];
 uint32_t unknown;
 uint32_t checksum;
 uint32_t realSize;
 char padding[12];
}
```

### SData
The first 128 bytes of the SData files are read at the same time in the game client, which leads me to believe it's some kind of header/metadata for a custom file format similar to csv.
The structure is as follows:
```cpp
struct SData {
 char header[128];
 uint32_t fieldCount;
 Field* fields;
 uint32_t recordCount;
 Record* records; // totalBytes = fieldCount * 8 * recordCount
}

struct Field {
 uint8_t fieldNameLength;
 char* fieldName; // size = fieldNameLength
}
```

**All record value types are `int64`**.

## DBItemData

```cpp
struct DBItemDataRecord {
  int64_t itemtype;
  int64_t itemtypeid;
  int64_t image;
  int64_t icon;
  int64_t level;
  int64_t country;
  int64_t attackfighter;
  int64_t defensefighter;
  int64_t patrolrogue;
  int64_t shootrogue;
  int64_t attackmage;
  int64_t defensemage;
  int64_t grow;
  int64_t str;
  int64_t dex;
  int64_t rec;
  int64_t intl;
  int64_t wis;
  int64_t luc;
  int64_t vg;
  int64_t og;
  int64_t ig;
  int64_t range;
  int64_t attacktime;
  int64_t attrib;
  int64_t special;
  int64_t slot;
  int64_t quality;
  int64_t effect1;
  int64_t effect2;
  int64_t effect3;
  int64_t effect4;
  int64_t consthp;
  int64_t constsp;
  int64_t constmp;
  int64_t conststr;
  int64_t constdex;
  int64_t constrec;
  int64_t constint;
  int64_t constwis;
  int64_t constluc;
  int64_t speed;
  int64_t exp;
  int64_t buy;
  int64_t sell;
  int64_t grade;
  int64_t drop;
  int64_t server;
  int64_t count;
  int64_t duration;
  int64_t extduration;
  int64_t secoption;
  int64_t optionrate;
  int64_t buymethod;
  int64_t maxlevel;
  int64_t weaponpart;
  int64_t dyeingtype;
  int64_t arg3;
  int64_t arg4;
  int64_t usecontype;
  int64_t useconvar;
  int64_t moneytype;
  int64_t itemskill;
  int64_t itemupgrade;
  int64_t arg10;
  int64_t genecount;
  int64_t arg12;
  int64_t spellbookexp;
  int64_t spellbookdurability;
  int64_t casttime;
}
```

### DBItemText
```cpp
struct String {
  uint32_t length;
  char* str;
}

struct DBItemTextRecord {
  uint64_t itemtype;
  uint64_t itemtypeid;
  String itemname;
  String text;
}
```

### DBMonsterData
```cpp
struct DBMonsterDataRecord {
  int64_t id;
  int64_t image;
  int64_t level;
  int64_t exp;
  int64_t ai;
  int64_t money1;
  int64_t money2;
  int64_t item1;
  int64_t itemdroprate1;
  int64_t item2;
  int64_t itemdroprate2;
  int64_t item3;
  int64_t itemdroprate3;
  int64_t item4;
  int64_t itemdroprate4;
  int64_t item5;
  int64_t itemdroprate5;
  int64_t item6;
  int64_t itemdroprate6;
  int64_t item7;
  int64_t itemdroprate7;
  int64_t item8;
  int64_t itemdroprate8;
  int64_t item9;
  int64_t itemdroprate9;
  int64_t questitem;
  int64_t hp;
  int64_t sp;
  int64_t mp;
  int64_t dex;
  int64_t wis;
  int64_t luc;
  int64_t day;
  int64_t size;
  int64_t attrib;
  int64_t defense;
  int64_t magic;
  int64_t state1;
  int64_t state2;
  int64_t state3;
  int64_t state4;
  int64_t state5;
  int64_t state6;
  int64_t state7;
  int64_t state8;
  int64_t state9;
  int64_t state10;
  int64_t state11;
  int64_t state12;
  int64_t state13;
  int64_t state14;
  int64_t state15;
  int64_t skill1;
  int64_t skill2;
  int64_t skill3;
  int64_t skill4;
  int64_t skill5;
  int64_t skill6;
  int64_t normaltime;
  int64_t normalstep;
  int64_t chasetime;
  int64_t chasestep;
  int64_t chaserange;
  int64_t attackani1;
  int64_t attacktype1;
  int64_t attacktime1;
  int64_t attackrange1;
  int64_t attack1;
  int64_t attackplus1;
  int64_t attackattrib1;
  int64_t attackspecial1;
  int64_t attackok1;
  int64_t attackani2;
  int64_t attacktype2;
  int64_t attacktime2;
  int64_t attackrange2;
  int64_t attack2;
  int64_t attackplus2;
  int64_t attackattrib2;
  int64_t attackspecial2;
  int64_t attackok2;
  int64_t attackani3;
  int64_t attacktype3;
  int64_t attacktime3;
  int64_t attackrange3;
  int64_t attack3;
  int64_t attackplus3;
  int64_t attackattrib3;
  int64_t attackspecial3;
  int64_t attackok3;
  int64_t colortype;
  int64_t colorhue;
  int64_t colorsaturation;
  int64_t colorlight;
}
```

### DBMonsterText
```cpp
struct String {
  uint32_t length;
  char* str;
}

struct DBMonsterTextRecord {
 uint64_t id;
 String name;
}
```

### DBSkillData
```cpp
struct DBSkillDataRecord {
  int64_t id;
  int64_t skilllevel;
  int64_t image;
  int64_t ani;
  int64_t effect;
  int64_t toggletype;
  int64_t sound;
  int64_t level;
  int64_t country;
  int64_t attackfighter;
  int64_t defensefighter;
  int64_t patrolrogue;
  int64_t shootrogue;
  int64_t attackmage;
  int64_t defensemage;
  int64_t grow;
  int64_t point;
  int64_t typeshow;
  int64_t typeattack;
  int64_t typeeffect;
  int64_t type;
  int64_t needweapon1;
  int64_t needweapon2;
  int64_t needweapon3;
  int64_t needweapon4;
  int64_t needweapon5;
  int64_t needweapon6;
  int64_t needweapon7;
  int64_t needweapon8;
  int64_t needweapon9;
  int64_t needweapon10;
  int64_t needweapon11;
  int64_t needweapon12;
  int64_t needweapon13;
  int64_t needweapon14;
  int64_t needweapon15;
  int64_t shield;
  int64_t sp;
  int64_t mp;
  int64_t readytime;
  int64_t resettime;
  int64_t attackrange;
  int64_t statetype;
  int64_t attribtype;
  int64_t disable;
  int64_t prevskill;
  int64_t successtype;
  int64_t successvalue;
  int64_t targettype;
  int64_t applyrange;
  int64_t multiattack;
  int64_t keeptime;
  int64_t weapon1;
  int64_t weapon2;
  int64_t weaponvalue;
  int64_t bag;
  int64_t arrow;
  int64_t damagetype;
  int64_t damage1;
  int64_t damage2;
  int64_t damage3;
  int64_t timedamagetype;
  int64_t timedamage1;
  int64_t timedamage2;
  int64_t timedamage3;
  int64_t adddamage1;
  int64_t adddamage2;
  int64_t adddamage3;
  int64_t abilitytype1;
  int64_t abilityvalue1;
  int64_t abilitytype2;
  int64_t abilityvalue2;
  int64_t abilitytype3;
  int64_t abilityvalue3;
  int64_t abilitytype4;
  int64_t abilityvalue4;
  int64_t abilitytype5;
  int64_t abilityvalue5;
  int64_t abilitytype6;
  int64_t abilityvalue6;
  int64_t abilitytype7;
  int64_t abilityvalue7;
  int64_t abilitytype8;
  int64_t abilityvalue8;
  int64_t abilitytype9;
  int64_t abilityvalue9;
  int64_t abilitytype10;
  int64_t abilityvalue10;
  int64_t heal1;
  int64_t heal2;
  int64_t heal3;
  int64_t timeheal1;
  int64_t timeheal2;
  int64_t timeheal3;
  int64_t defencetype;
  int64_t defencevalue;
  int64_t limithp;
  int64_t fixrange;
  int64_t changetype;
  int64_t changelevel;
  int64_t tacticzonebound;
}
```

### DBSkillText

```cpp
struct String {
  uint32_t length;
  char* str;
}

struct DBSkillTextRecord {
  uint64_t id;
  uint64_t skilllevel;
  String name;
  String text;
}
```

### DBItemSell
```cpp
struct DBItemSellRecord {
  uint64_t ProductCode;
  uint64_t goods_id;
  uint64_t Multi_BuyCost1;
  uint64_t Multi_BuyCost2;
  uint64_t ItemID1;
  uint64_t ItemCount1;
  uint64_t ItemID2;
  uint64_t ItemCount2;
  uint64_t ItemID3;
  uint64_t ItemCount3;
  uint64_t ItemID4;
  uint64_t ItemCount4;
  uint64_t ItemID5;
  uint64_t ItemCount5;
  uint64_t ItemID6;
  uint64_t ItemCount6;
  uint64_t ItemID7;
  uint64_t ItemCount7;
  uint64_t ItemID8;
  uint64_t ItemCount8;
  uint64_t ItemID9;
  uint64_t ItemCount9;
  uint64_t ItemID10;
  uint64_t ItemCount10;
  uint64_t ItemID11;
  uint64_t ItemCount11;
  uint64_t ItemID12;
  uint64_t ItemCount12;
  uint64_t ItemID13;
  uint64_t ItemCount13;
  uint64_t ItemID14;
  uint64_t ItemCount14;
  uint64_t ItemID15;
  uint64_t ItemCount15;
  uint64_t ItemID16;
  uint64_t ItemCount16;
  uint64_t ItemID17;
  uint64_t ItemCount17;
  uint64_t ItemID18;
  uint64_t ItemCount18;
  uint64_t ItemID19;
  uint64_t ItemCount19;
  uint64_t ItemID20;
  uint64_t ItemCount20;
  uint64_t ItemID21;
  uint64_t ItemCount21;
  uint64_t ItemID22;
  uint64_t ItemCount22;
  uint64_t ItemID23;
  uint64_t ItemCount23;
  uint64_t ItemID24;
  uint64_t ItemCount24;
  uint64_t type;
}
```

### DBItemSellText
```cpp
struct String {
  uint32_t length;
  char* str;
}

struct DBItemSellTextRecord {
  String ProductName;
  String text;
}
```

## DBSetItem
```cpp
struct DBSetItemRecord {
  int64_t id;
  int64_t category1;
  int64_t number1;
  int64_t category2;
  int64_t number2;
  int64_t category3;
  int64_t number3;
  int64_t category4;
  int64_t number4;
  int64_t category5;
  int64_t number5;
  int64_t category6;
  int64_t number6;
  int64_t category7;
  int64_t number7;
  int64_t category8;
  int64_t number8;
  int64_t category9;
  int64_t number9;
  int64_t category10;
  int64_t number10;
  int64_t category11;
  int64_t number11;
  int64_t category12;
  int64_t number12;
  int64_t category13;
  int64_t number13;
}
```

## DBSetItemText
```cpp
struct String {
  uint32_t length;
  char* str;
}

struct DBSetItemTextRecord {
  int64_t id;
  String name;
  String seteff1;
  String seteff2;
  String seteff3;
  String seteff4;
  String seteff5;
  String seteff6;
  String seteff7;
  String seteff8;
  String seteff9;
  String seteff10;
  String seteff11;
  String seteff12;
  String seteff13;
}
```

## DBNpcSkill
```cpp
struct DBNpcSkillRecord {
  int64_t id;
  int64_t skilllevel;
  int64_t image;
  int64_t ani;
  int64_t effect;
  int64_t toggletype;
  int64_t sound;
  int64_t level;
  int64_t country;
  int64_t attackfighter;
  int64_t defensefighter;
  int64_t patrolrogue;
  int64_t shootrogue;
  int64_t attackmage;
  int64_t defensemage;
  int64_t grow;
  int64_t point;
  int64_t typeshow;
  int64_t typeattack;
  int64_t typeeffect;
  int64_t type;
  int64_t needweapon1;
  int64_t needweapon2;
  int64_t needweapon3;
  int64_t needweapon4;
  int64_t needweapon5;
  int64_t needweapon6;
  int64_t needweapon7;
  int64_t needweapon8;
  int64_t needweapon9;
  int64_t needweapon10;
  int64_t needweapon11;
  int64_t needweapon12;
  int64_t needweapon13;
  int64_t needweapon14;
  int64_t needweapon15;
  int64_t shield;
  int64_t sp;
  int64_t mp;
  int64_t readytime;
  int64_t resettime;
  int64_t attackrange;
  int64_t statetype;
  int64_t attribtype;
  int64_t disable;
  int64_t prevskill;
  int64_t successtype;
  int64_t successvalue;
  int64_t targettype;
  int64_t applyrange;
  int64_t multiattack;
  int64_t keeptime;
  int64_t weapon1;
  int64_t weapon2;
  int64_t weaponvalue;
  int64_t bag;
  int64_t arrow;
  int64_t damagetype;
  int64_t damage1;
  int64_t damage2;
  int64_t damage3;
  int64_t timedamagetype;
  int64_t timedamage1;
  int64_t timedamage2;
  int64_t timedamage3;
  int64_t adddamage1;
  int64_t adddamage2;
  int64_t adddamage3;
  int64_t abilitytype1;
  int64_t abilityvalue1;
  int64_t abilitytype2;
  int64_t abilityvalue2;
  int64_t abilitytype3;
  int64_t abilityvalue3;
  int64_t abilitytype4;
  int64_t abilityvalue4;
  int64_t abilitytype5;
  int64_t abilityvalue5;
  int64_t abilitytype6;
  int64_t abilityvalue6;
  int64_t abilitytype7;
  int64_t abilityvalue7;
  int64_t abilitytype8;
  int64_t abilityvalue8;
  int64_t abilitytype9;
  int64_t abilityvalue9;
  int64_t abilitytype10;
  int64_t abilityvalue10;
  int64_t heal1;
  int64_t heal2;
  int64_t heal3;
  int64_t timeheal1;
  int64_t timeheal2;
  int64_t timeheal3;
  int64_t defencetype;
  int64_t defencevalue;
  int64_t limithp;
  int64_t fixrange;
  int64_t changetype;
  int64_t changelevel;
}
```

## DBNpcSkillText
```cpp
struct String {
  uint32_t length;
  char* str;
}

struct DBNpcSkillTextRecord {
  uint64_t id;
  uint64_t skilllevel;
  String name;
  String text;
}
````

## DBDualLayerClothes
```cpp
struct DBDualLayerClothesRecord {
  int64_t id;
  int64_t top;
  int64_t hand;
  int64_t bottom;
  int64_t shoe;
  int64_t empty;
  int64_t helmet;
}
```

## DBSetItemData
```cpp
struct DbSetItemDataRecord {
  int64_t id;
  int64_t category1;
  int64_t number1;
  int64_t category2;
  int64_t number2;
  int64_t category3;
  int64_t number3;
  int64_t category4;
  int64_t number4;
  int64_t category5;
  int64_t number5;
  int64_t category6;
  int64_t number6;
  int64_t category7;
  int64_t number7;
  int64_t category8;
  int64_t number8;
  int64_t category9;
  int64_t number9;
  int64_t category10;
  int64_t number10;
  int64_t category11;
  int64_t number11;
  int64_t category12;
  int64_t number12;
  int64_t category13;
  int64_t number13;
}
```

## DBSetItemText
```cpp
struct String {
  uint32_t length;
  char* str;
}

struct DBSetItemTextRecord
{
  int64_t id;
  String name;
  int64_t seteff1;
  int64_t seteff2;
  int64_t seteff3;
  int64_t seteff4;
  int64_t seteff5;
  int64_t seteff6;
  int64_t seteff7;
  int64_t seteff8;
  int64_t seteff9;
  int64_t seteff10;
  int64_t seteff11;
  int64_t seteff12;
  int64_t seteff13;
}
```

## DBTransformModelData
```cpp
struct DBTransformModelDataRecord {
  int64_t id;
  int64_t top;
  int64_t hand;
  int64_t bottom;
  int64_t shoe;
  int64_t empty;
  int64_t helmet;
}
```
## DBTransformWeaponModelData
```cpp
struct DBTransformWeaponModelDataRecord {
  int64_t type;
  int64_t weapon;
  int64_t weapon1;
}
```