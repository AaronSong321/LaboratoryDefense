using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Description
{
    public enum Language { English, Chinese};

    public static Language GetLanguage(String s)
    {
        Description.Language ans;
        switch(s)
        {
            case "English": ans = Language.English;
                break;
            case "中文（简体）":ans = Language.Chinese;
                break;
            default: ans = Language.English;
                break;
        }
        return ans;
    }

    public static String MachineMastery(Language l)
    {
        String answer="";
        switch (l)
        {
            case Language.English: answer = "Properties:\n" +
                "    MachineGun, Pillbox basic damage increase: 1% per level\n" +
                "    Sniper, CrossbowHunter basic damage increase: 0.6% per level\n" +
                "    Sniper, CrossbowHunter basic firing rate increase: 0.1 per level\n" +
                "    Initialize money bonus: 1.2% per level\n" +
                "    \n" +
                "Abilities:\n" +
                "    level 10:\n" +
                "        Armour-piercing bullet: Increase the damage of MachineGun, Sniper, CrossbowHunter, PillBox 25%.\n" +
                "        Cash bonus: Every enemy killed provides a cash bonus of 40%.\n" +
                "    level 20:\n" +
                "        Never fly away: Enable MachineGun and PillBox to shoot flying enemies.\n" +
                "        Ramrod and reload: Increase the firing rate of CrossbowHunter and Sniper 12.\n" +
                "    level 30:\n" +
                "        Bullets and shells: MachineGun slow enemies 15%/20%/24% for 3s.\n" +
                "        All by hands: Increase the effectiveness duration of MolotovCocktail 2s.\n" +
                "    level 40:\n" +
                "        Crazy boy: Increase the firing rate of MachineGun and PillBox 40/50/60.\n" +
                "        Multimillionaire: Every Mamoth, BristleTank and Dragon killed provides a cash bonus of 70%, which can be overlayed from Cash bonus.\n" +
                "    level 50:\n" +
                "        Fat penalty: Every shot from Sniper will do an extra damage equal to 20% of the maximum health of the target. The maximum extra damage is 900.\n" +
                "        Dud versus head: Rocket can shoot in any distance; when shooting from a distance shorter than the original minimum, the rocket shell deals 4/6/8 times of the bullet damage without explosion.\n";
                break;
            case Language.Chinese: answer = "属性：\n" +
                "    哨兵枪，机枪碉堡伤害增加：每级1%\n" +
                "    狙击塔，猎人塔伤害增加：每级0.6%\n" +
                "    狙击塔，猎人塔攻击速度增肌：每级0.1\n" +
                "    基础金钱增加：每级1.2%\n" +
                "\n" +
                "技能：\n" +
                "    等级10：\n" +
                "        穿甲弹：增加哨兵枪，狙击塔，猎人塔，机枪碉堡伤害25%。\n" +
                "        现金奖励：增加杀死任意敌人的金钱奖励40%。\n" +
                "    等级20：\n" +
                "        别想飞走：使得哨兵枪，机枪碉堡可以攻击空中单位。\n" +
                "        推弹上膛：增加猎人塔，狙击塔攻击速度12。\n" +
                "    等级30：\n" +
                "        枪林弹雨：哨兵枪的攻击降低敌人移动速度15%/20%/24%，持续3s。\n" +
                "        纯手工制作：增加燃烧瓶持续时间2s。\n" +
                "    等级40：\n" +
                "        扫射：增加哨兵枪，机枪碉堡攻击速度40/50/60。\n" +
                "        百万富翁：增加杀死大型敌人的金钱奖励70%，可以与现金奖励叠加。\n" +
                "    等级50：\n" +
                "        肥胖惩罚：狙击塔每次攻击对敌人造成其最大生命值20%的额外伤害，最大额外伤害为900。\n" +
                "        爆头：允许火箭弹可以在任意不超过最大射程的距离开火；如果射击距离小于预定的最小射程，则会造成4/6/8倍的子弹伤害，但不发生爆炸。\n";
                break;
            default: answer = "Unknown language pack."; break;
        }
        return answer;
    }

    public static String MadBomber(Language l)
    {
        String answer = "";
        switch(l)
        {
            case Language.English: answer = "Properties:\n" +
                "    SharpnelThrower, Rocket, PatriotMissile explosion damage increase: 1% per level\n" +
                "    SharpnelThrower, Rocket, PatriotMissile explosion range increase: 0.2% per level\n" +
                "    Experience gained increase: 25%\n" +
                "\nAbilities:\n" +
                "    level 10:\n" +
                "        SpeedLoader: Increase firing rate of PatriotMissile, Rocket, SharpnelThrower 20%.\n" +
                "        Aggregation: Decrease explosion range of PatriotMissile, Rocket 35%, but increase the explosion damage of PatriotMissile, Rocket 40%. \n" +
                "    level 20:\n" +
                "        High explosion: Increase explosion damage of PatriotMissile, Rocket, SharpnelThrower 20%.\n" +
                "        Back off: The direct hit of PatriotMissile, Rocket can stun the target typed tiny, common or giant for 0.4s.\n" +
                "    level 30:\n" +
                "        A new type: MachineGun and PillBox deal explosive damage with an explosion range of 30.\n" +
                "        Another catastrophy: Increase MachineGun, PillBox, Prisim damage 50%.\n" +
                "    level 40:\n" +
                "        Snipe with explosives: Increase range of PatriotMissile, Rocket, SharpnelThrower 30%." +
                "        Bully: Upgrade PatriotMissile, Rocket, SharpnelThrower, ignoring explosion resistance when attacking enemies typed tiny or common.\n" +
                "    level 50:\n" +
                "        Final core: Increase Rocket damage to enemies typed giant or boss 40%.\n" +
                "        Nuclear Bomber: Give Rocket and PatriotMissile a chance of 5% to release a nuclear explosion, which can deal an extra explosion, with a range of 80, damage 50 for 8s. Both the direct and following damages are typed nuclear.\n";
                break;
            case Language.Chinese: answer = "属性：\n" +
                "    榴弹发射器，火箭弹，导弹塔爆炸伤害增加：每级1%\n" +
                "    榴弹发射器，火箭弹，导弹塔爆炸范围增加：每级0.2%\n" +
                "    经验增加：25%\n" +
                "\n技能：\n" +
                "    等级10：\n" +
                "        装弹器：增加榴弹发射器，火箭弹导弹塔攻击速度20%。\n" +
                "        密集轰炸：降低火箭弹，导弹塔爆炸范围35%，但是爆炸伤害增加40%。\n" +
                "    等级20：\n" +
                "        高爆弹：增加榴弹发射器，火箭弹，导弹塔爆炸伤害20%。\n" +
                "        致退：火箭弹，导弹塔的直接攻击会可以眩晕小型，中型或大型的敌人0.4s。\n" +
                "    等级30：\n" +
                "        爆炸型号：哨兵枪，机枪碉堡造成爆炸伤害，范围为30。\n" +
                "        额外灾难：增加哨兵枪，机枪碉堡，电击塔攻击力50%。\n" +
                "    等级40：\n" +
                "        远程狙击：增加榴弹发射器，火箭弹，导弹塔最大攻击范围30%。\n" +
                "        欺凌弱小：使得榴弹发射器，火箭弹，导弹塔攻击小型或中型敌人时无视伤害抗性。\n" +
                "    等级50：\n" +
                "        终极进化：增加导弹塔对大型敌人或boss伤害40%。\n" +
                "        核弹井：火箭弹，导弹塔有5%的几率打出核弹，对范围80内的敌人每秒造成50点伤害，持续8s。核弹的所有伤害均为核能。\n";
                break;
            default: answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String FireRanger(Language l)
    {
        String answer = "";
        switch(l)
        {
            case Language.English: answer = "Properties:\n" +
                "    FlameThrower, MolotovCocktail, Micro flame damage increase: 1% per level\n" +
                "    SharpnelThrower, Rocket, PatriotMissile explosion explosion damage increase: 0.4% per level\n" +
                "    Transformer tesla damage increase: 0.4% per level\n" +
                "\nAbilities:\n" +
                "    level 10:\n" +
                "        Barbecue: Increase flame damage 25%.\n" +
                "        Gasoline and coke: Increase FlameThrower, MolotovCocktail, Macro range 10%.\n" +
                "    level 20:\n" +
                "        Well done: Increase flame duration 1s.\n" +
                "        Macro-cooked: Enemies being affected by Macro are slowed 10%.\n" +
                "    level 30:\n" +
                "        Double-edged sword: Decrease Macro damage to enemies typed tiny 50%, but increase macro damage to enemies typed giant 50%.\n" +
                "        Fire Armor: Increase health point of the basement 30%, and decrease damage from enemies typed giant 20%.\n" +
                "    level 40:\n" +
                "        FireHunter: CrossbowHunter deals flame damage, and the minimum range decreases to 0.\n" +
                "        MultiHeat: Enemies can be affected by FlameThrower, MolotovCocktail, Macro at the meantime, and the damage is overlayed linearly.\n" +
                "    level 50:\n" +
                "        Air rush: Enable Macro to attack air units.\n" +
                "        Disarm: Upgrade FlameThrower, MolotovCocktail, Macro, ignoring flame resistance when attacking enemies typed tiny, common or giant.\n";
                break;
            case Language.Chinese: answer = "属性：\n" +
                "    火焰喷射器，燃烧瓶，微波塔伤害增加：每级1%\n" +
                "    榴弹发射器，火箭弹，导弹塔爆炸伤害增加：每级0.4%\n" +
                "    变压器伤害增加：每级0.4%\n" +
                "\n技能：\n" +
                "    等级10：\n" +
                "        我的烤肉呢：增加火焰喷射器，燃烧瓶，微波塔伤害25%。\n" +
                "        汽油与焦炭：增加火焰喷射器，燃烧瓶，微波塔最大射程10%。\n" +
                "    等级20：\n" +
                "        全熟的烤饼：增加火焰喷射器，燃烧瓶，微波塔的燃烧持续时间1s。\n" +
                "        缓慢烹饪：受微波塔影响的敌人移动速度降低10%。\n" +
                "    等级30：\n" +
                "        双刃剑：降低微波塔对小型敌人50%的伤害，但是增加其对大型敌人的伤害50%。\n" +
                "        火焰装甲：增加基地生命值30%，降低基地受到大型敌人伤害20%。\n" +
                "    等级40：\n" +
                "        火焰箭矢：猎人塔造成火焰伤害，最小生成降低为0。这样的猎人塔还会享受这个职业的属性加成。\n" +
                "        反复烹饪：火焰喷射器，燃烧瓶，微波塔的灼烧效果线性叠加。\n" +
                "    等级50：\n" +
                "        坠机：允许微波塔攻击飞行单位。\n" +
                "        缴械：使得火焰喷射器，燃烧瓶，微波塔在攻击小型，中型或大型的敌人时无视火焰抗性。\n";
                break;
            default:answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String ThunderSpirit(Language l)
    {
        String answer = "";
        switch(l)
        {
            case Language.English: answer = "Properties:\n" +
                "    Prisim, Transformer, Thunder disability duration increase: 0.7% per level\n" +
                "    Thunder shots towards air units stun possibility increase: 0.1\n" +
                "    Transformer slow duration increase: 0.2s per 10 level\n" +
                "    Prisim, Transformer, Thunder damage increase: 1% per level\n" +
                "    Prisim firing rate increase: 0.6 per level\n" +
                "\nAbilities:\n" +
                "    level 10:\n" +
                "        Basic solution: Increase Transformer damage 30% and firing rate 15.\n" +
                "        Heavy lightening: Increase Thunder stun duration 0.2s.\n" +
                "    level 20:\n" +
                "        Seckill: The shot from Thunder has a possibility of 0.1/0.2/0.3 to seckill the target enemy typed tiny or common.\n" +
                "        Every warning: The shot from Prisim has a possibility of 0.25 to stun enemies typed tiny for 1s.\n" +
                "    level 30:\n" +
                "        Rail Gun: Sniper deals tesla damage, and has a possibility of 0.1 to stun the target for 0.4s. Besides, Sniper enjoys the property of damage increase and disability duration increase.\n" +
                "        No pass: Increase Transformer range 30%.\n" +
                "    level 40:\n" +
                "        Electromagnetic pulse: SharpnelThrower deals tesla damage, and slows enemies 15% for 0.6s.Besides, SharpnelThrower enjoys the property of damage increase and disability duration increase.\n" +
                "        Collective punishment: Prisim can attack two enemies in one shot, but firing rate decreases by 30.\n" +
                "    level 50:\n" +
                "        Electrical fire: Micro deals tesla damage. Besides, Micro enjoys the property of damage increase.\n" +
                "        Double damage: Every stun with Prisim, Thunder, Sniper, CrossbowHunter deals an extra damage equal to the damage of that tower.\n";
                break;
            case Language.Chinese: answer = "属性：\n" +
                "    电击塔，变压器，闪电塔眩晕时间增加：每级0.7%\n" +
                "    闪电塔攻击对空中单位的眩晕几率增加：10%\n" +
                "    变压器减速时间增加：每10级0.2s\n" +
                "    电击塔，变压器，闪电塔伤害增加：每级1%\n" +
                "    电击塔攻击速度增加：每级0.6\n" +
                "\n技能：\n" +
                "    等级10：\n" +
                "        基础方案：增加变压器伤害30%和攻击速度15点。\n" +
                "        重击：增加闪电塔眩晕时间0.2s。\n" +
                "    等级20：\n" +
                "        秒杀：闪电塔有10%/20%/30%的几率秒杀小型或中型的敌人。\n" +
                "        步步警告：电击塔对小型敌人的攻击有25%的几率造成1s的眩晕。\n" +
                "    等级30：\n" +
                "        轨道炮：狙击塔造成电磁伤害，并且有10%的几率眩晕目标0.4s。这样的狙击塔还会享受这个职业的属性加成。\n" +
                "        禁止通行：增加变压器射程30%。\n" +
                "    等级40：\n" +
                "        断电榴弹：榴弹发射器造成电磁伤害，并且对敌人造成15%的减速，持续0.6s。这样的榴弹发射器还会享受这个职业的属性加成。\n" +
                "        密集惩罚：电击塔能在一次攻击中攻击两个敌人，但是攻击速度降低30。\n" +
                "    等级50：\n" +
                "        电火：微波塔造成电磁伤害。这样的微波塔还会享受这个职业的属性加成\n" +
                "        双倍伤害：当电击塔，闪电塔，狙击塔，猎人塔造成电磁型眩晕时，会增加一个等用于伤害来源攻击力的额外伤害。\n";
                break;
        }
        return answer;
    }

    public static String Elfin(Language l)
    {
        String answer = "";
        switch(l)
        {
            case Language.English: answer = "name: Elfin\n" +
                "size: tiny\n" +
                "health point: 92\n" +
                "speed: 120\n" +
                "damage: 1\n" +
                "type: ground\n" +
                "money bonus: 7\n" +
                "resistance\n" +
                "    bullet: 1\n" +
                "    explosive: 0.8\n" +
                "    tesla: 0.6\n" +
                "    flame: 1\n" +
                "    nuclear: 1\n";
                break;
            case Language.Chinese: answer = "名字：小精灵\n" +
                "体型：小型\n" +
                "生命值：92\n" +
                "速度：120\n" +
                "攻击力：1\n" +
                "类型：地面单位\n" +
                "金钱奖励：7\n" +
                "伤害抗性：\n" +
                "    子弹抗性：1\n" +
                "    爆炸抗性：0.8\n" +
                "    电磁抗性：0.6\n" +
                "    火焰抗性：1\n" +
                "    核能抗性：1\n";
                break;
            default: answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String Crawler(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "name: Crawler\n" +
                 "size: tiny\n" +
                 "health point: 60\n" +
                 "speed: 200\n" +
                 "damage: 1\n" +
                 "type: ground\n" +
                 "money bonus: 7\n" +
                 "resistance\n" +
                 "    bullet: 1\n" +
                 "    explosive: 1\n" +
                 "    tesla: 1\n" +
                 "    flame: 1\n" +
                 "    nuclear: 1\n";
                break;
            case Language.Chinese:
                answer = "名字：爬行者\n" +
                 "体型：小型\n" +
                 "生命值：60\n" +
                 "速度：200\n" +
                 "攻击力：1\n" +
                 "类型：地面单位\n" +
                 "金钱奖励：7\n" +
                 "伤害抗性：\n" +
                 "    子弹抗性：1\n" +
                 "    爆炸抗性：1\n" +
                 "    电磁抗性：1\n" +
                 "    火焰抗性：1\n" +
                 "    核能抗性：1\n";
                break;
            default:
                answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String Zombie(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "name: Zombie\n" +
                 "size: tiny\n" +
                 "health point: 180\n" +
                 "speed: 80\n" +
                 "damage: 1\n" +
                 "type: ground\n" +
                 "money bonus: 13\n" +
                 "resistance\n" +
                 "    bullet: 0.7\n" +
                 "    explosive: 0.8\n" +
                 "    tesla: 0.6\n" +
                 "    flame: 1\n" +
                 "    nuclear: 1\n";
                break;
            case Language.Chinese:
                answer = "名字：僵尸\n" +
                 "体型：小型\n" +
                 "生命值：180\n" +
                 "速度：80\n" +
                 "攻击力：1\n" +
                 "类型：地面单位\n" +
                 "金钱奖励：13\n" +
                 "伤害抗性：\n" +
                 "    子弹抗性：1\n" +
                 "    爆炸抗性：1\n" +
                 "    电磁抗性：1\n" +
                 "    火焰抗性：1\n" +
                 "    核能抗性：1\n";
                break;
            default:
                answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String Thirsty(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "name: Thirsty\n" +
                 "size: tiny\n" +
                 "health point: 70\n" +
                 "speed: 130\n" +
                 "damage: 1\n" +
                 "type: air\n" +
                 "money bonus: 9\n" +
                 "resistance\n" +
                 "    bullet: 1.2\n" +
                 "    explosive: 1\n" +
                 "    tesla: 1\n" +
                 "    flame: 1\n" +
                 "    nuclear: 1\n";
                break;
            case Language.Chinese:
                answer = "名字：嗜血者\n" +
                 "体型：小型\n" +
                 "生命值：70\n" +
                 "速度：130\n" +
                 "攻击力：1\n" +
                 "类型：空中单位\n" +
                 "金钱奖励：9\n" +
                 "伤害抗性：\n" +
                 "    子弹抗性：1.2\n" +
                 "    爆炸抗性：1\n" +
                 "    电磁抗性：1\n" +
                 "    火焰抗性：1\n" +
                 "    核能抗性：1\n";
                break;
            default:
                answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String Butcher(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "name: Butcher\n" +
                 "size: tiny\n" +
                 "health point: 650\n" +
                 "speed: 100\n" +
                 "damage: 2\n" +
                 "type: ground\n" +
                 "money bonus: 18\n" +
                 "resistance\n" +
                 "    bullet: 0.7\n" +
                 "    explosive: 0.7\n" +
                 "    tesla: 1\n" +
                 "    flame: 1.5\n" +
                 "    nuclear: 1\n";
                break;
            case Language.Chinese:
                answer = "名字：屠夫\n" +
                 "体型：中型\n" +
                 "生命值：650\n" +
                 "速度：100\n" +
                 "攻击力：2\n" +
                 "类型：地面单位\n" +
                 "金钱奖励：7\n" +
                 "伤害抗性：\n" +
                 "    子弹抗性：0.7\n" +
                 "    爆炸抗性：0.7\n" +
                 "    电磁抗性：1\n" +
                 "    火焰抗性：1.5\n" +
                 "    核能抗性：1\n";
                break;
            default:
                answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String Unicron(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "name: Unicorn\n" +
                 "size: common\n" +
                 "health point: 750\n" +
                 "speed: 130\n" +
                 "damage: 2\n" +
                 "type: ground\n" +
                 "money bonus: 20\n" +
                 "resistance\n" +
                 "    bullet: 0.8\n" +
                 "    explosive: 1\n" +
                 "    tesla: 1\n" +
                 "    flame: 1\n" +
                 "    nuclear: 1\n";
                break;
            case Language.Chinese:
                answer = "名字：独角兽\n" +
                 "体型：中型\n" +
                 "生命值：750\n" +
                 "速度：130\n" +
                 "攻击力：2\n" +
                 "类型：地面单位\n" +
                 "金钱奖励：20\n" +
                 "伤害抗性：\n" +
                 "    子弹抗性：0.8\n" +
                 "    爆炸抗性：1\n" +
                 "    电磁抗性：1\n" +
                 "    火焰抗性：1\n" +
                 "    核能抗性：1\n";
                break;
            default:
                answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String Desolator(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "name: Desolator\n" +
                 "size: tiny\n" +
                 "health point: 900\n" +
                 "speed: 110\n" +
                 "damage: 3\n" +
                 "type: ground\n" +
                 "money bonus: 26\n" +
                 "resistance\n" +
                 "    bullet: 1\n" +
                 "    explosive: 1\n" +
                 "    tesla: 1\n" +
                 "    flame: 1\n" +
                 "    nuclear: 1\n";
                break;
            case Language.Chinese:
                answer = "名字：拾荒者\n" +
                 "体型：中型\n" +
                 "生命值：900\n" +
                 "速度：110\n" +
                 "攻击力：3\n" +
                 "类型：地面单位\n" +
                 "金钱奖励：26\n" +
                 "伤害抗性：\n" +
                 "    子弹抗性：1\n" +
                 "    爆炸抗性：1\n" +
                 "    电磁抗性：1\n" +
                 "    火焰抗性：1\n" +
                 "    核能抗性：1\n";
                break;
            default:
                answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String Manmoth(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "name: Manmoth\n" +
                 "size: giant\n" +
                 "health point: 3200\n" +
                 "speed: 110\n" +
                 "damage: 6\n" +
                 "type: ground\n" +
                 "money bonus: 65\n" +
                 "resistance\n" +
                 "    bullet: 0.7\n" +
                 "    explosive: 1.3\n" +
                 "    tesla: 1\n" +
                 "    flame: 1\n" +
                 "    nuclear: 1\n";
                break;
            case Language.Chinese:
                answer = "名字：猛犸\n" +
                 "体型：大型\n" +
                 "生命值：3200\n" +
                 "速度：110\n" +
                 "攻击力：6\n" +
                 "类型：地面单位\n" +
                 "金钱奖励：65\n" +
                 "伤害抗性：\n" +
                 "    子弹抗性：0.7\n" +
                 "    爆炸抗性：1.3\n" +
                 "    电磁抗性：1\n" +
                 "    火焰抗性：1\n" +
                 "    核能抗性：1\n";
                break;
            default:
                answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String Tank(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "name: Tank\n" +
                 "size: giant\n" +
                 "health point: 4800\n" +
                 "speed: 110\n" +
                 "damage: 1\n" +
                 "type: ground\n" +
                 "money bonus: 7\n" +
                 "resistance\n" +
                 "    bullet: 0.6\n" +
                 "    explosive: 1.4\n" +
                 "    tesla: 0.6\n" +
                 "    flame: 0.6\n" +
                 "    nuclear: 1\n";
                break;
            case Language.Chinese:
                answer = "名字：坦克\n" +
                 "体型：小型\n" +
                 "生命值：4800\n" +
                 "速度：110\n" +
                 "攻击力：8\n" +
                 "类型：地面单位\n" +
                 "金钱奖励：7\n" +
                 "伤害抗性：\n" +
                 "    子弹抗性：0.6\n" +
                 "    爆炸抗性：1.4\n" +
                 "    电磁抗性：0.6\n" +
                 "    火焰抗性：0.6\n" +
                 "    核能抗性：1\n";
                break;
            default:
                answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String Dragon(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "name: Dragon\n" +
                 "size: giant\n" +
                 "health point: 3500\n" +
                 "speed: 110\n" +
                 "damage: 7\n" +
                 "type: air\n" +
                 "money bonus: 75\n" +
                 "resistance\n" +
                 "    bullet: 1\n" +
                 "    explosive: 1\n" +
                 "    tesla: 1\n" +
                 "    flame: 0.65\n" +
                 "    nuclear: 1\n";
                break;
            case Language.Chinese:
                answer = "名字：巨龙\n" +
                 "体型：大型\n" +
                 "生命值：3500\n" +
                 "速度：110\n" +
                 "攻击力：7\n" +
                 "类型：空中单位\n" +
                 "金钱奖励：75\n" +
                 "伤害抗性：\n" +
                 "    子弹抗性：1\n" +
                 "    爆炸抗性：1\n" +
                 "    电磁抗性：1\n" +
                 "    火焰抗性：0.65\n" +
                 "    核能抗性：1\n";
                break;
            default:
                answer = "Unknown language pack.";
                break;
        }
        return answer;
    }

    public static String MachineGun(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English: answer = "Name: MachineGun\n" +
                    "Damage: 35/45/55\n" +
                    "Attack Type: bullet\n" +
                    "Firing Rate: 140/210/280\n" +
                    "Range: 0-220\n" +
                    "Cost: 100\n" +
                    "Target Type: ground\n";
                break;
            case Language.Chinese: answer = "名字：哨兵枪\n" +
                    "伤害：36/45/55\n" +
                    "攻击类型：子弹\n" +
                    "攻击速度：140/210/280\n" +
                    "射程：0-220\n" +
                    "造价：100/80/140\n" +
                    "目标类型：地面单位\n";
                break;
            default: answer = "Unknown language pack";
                break;
        }
        return answer;
    }

    public static String Sniper(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "Name: Sniper\n" +
                     "Damage: 300/500/700\n" +
                     "Attack Type: bullet\n" +
                     "Firing Rate: 56\n" +
                     "Range: 0-550\n" +
                     "Cost: 400/250/250\n" +
                     "Target Type: ground\n";
                break;
            case Language.Chinese:
                answer = "名字：狙击塔\n" +
                     "伤害：300/500/700\n" +
                     "攻击类型：子弹\n" +
                     "攻击速度：56\n" +
                     "射程：0-550\n" +
                     "造价：400/250/250\n" +
                     "目标类型：地面单位\n";
                break;
            default:
                answer = "Unknown language pack";
                break;
        }
        return answer;
    }

    public static String PillBox(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "Name: PillBox\n" +
                     "Damage: 50/85/120\n" +
                     "Attack Type: bullet\n" +
                     "Firing Rate: 280/336/392\n" +
                     "Range: 0-260\n" +
                     "Cost: 260/280/300\n" +
                     "Target Type: ground\n";
                break;
            case Language.Chinese:
                answer = "名字：狙击塔\n" +
                     "伤害：50/85/120\n" +
                     "攻击类型：子弹\n" +
                     "攻击速度：280/336/392\n" +
                     "射程：0-260\n" +
                     "造价：260/280/300\n" +
                     "目标类型：地面单位\n";
                break;
            default:
                answer = "Unknown language pack";
                break;
        }
        return answer;
    }

    public static String CrossbowHunter(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "Name: CrossbowHunter\n" +
                     "Damage: 110/220/330\n" +
                     "Attack Type: bullet\n" +
                     "Firing Rate: 70\n" +
                     "Stun Possibility: 0.07\n" +
                     "Stun Duration: 0.5/0.7/0.9\n" +
                     "Range: 100-400\n" +
                     "Cost: 210/190/190\n" +
                     "Target Type: ground or air\n";
                break;
            case Language.Chinese:
                answer = "名字：狙击塔\n" +
                     "伤害：110/220/330\n" +
                     "攻击类型：子弹\n" +
                     "攻击速度：70\n" +
                     "眩晕几率：0.07\n" +
                     "眩晕时间：0.5/0.7/0.9\n" +
                     "射程：100-400\n" +
                     "造价：210/190/190\n" +
                     "目标类型：地面单位，空中单位\n";
                break;
            default:
                answer = "Unknown language pack";
                break;
        }
        return answer;
    }

    public static String SharpnelThrower(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "Name: SharpnelThrower\n" +
                     "Damage: 70/105/140\n" +
                     "Attack Type: explosive\n" +
                     "Explosion Radius: 80/90/100\n" +
                     "Firing Rate: 84/98/112\n" +
                     "Range: 150-350/150-380/150-420\n" +
                     "Cost: 180/160/240\n" +
                     "Target Type: ground\n";
                break;
            case Language.Chinese:
                answer = "名字：榴弹发射器\n" +
                     "伤害： 70/105/140\n" +
                     "攻击类型：爆炸\n" +
                     "爆炸半径：80/90/100\n" +
                     "攻击速度：84/98/112\n" +
                     "射程：150-350/150-380/150-420\n" +
                     "造价：180/160/240\n" +
                     "目标类型：地面单位\n";
                break;
            default:
                answer = "Unknown language pack";
                break;
        }
        return answer;
    }

    public static String Rocket(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "Name: Rocket\n" +
                     "Damage: 100/120/180\n" +
                     "Attack Type: bullet\n" +
                     "Damage: 150/250/350\n" +
                     "Attack Type: explosive\n" +
                     "Explosion Radius: 50\n" +
                     "Firing Rate: 70\n" +
                     "Range: 100-450\n" +
                     "Cost: 450/400/480\n" +
                     "Target Type: ground or air\n";
                break;
            case Language.Chinese:
                answer = "名字：火箭弹\n" +
                     "伤害： 100/120/180\n" +
                     "攻击类型：子弹\n" +
                     "伤害：150/200/250\n" +
                     "攻击类型：爆炸\n" +
                     "爆炸范围：50\n" +
                     "攻击速度：70\n" +
                     "射程：100-450\n" +
                     "造价：450/400/480\n" +
                     "目标类型：地面单位，空中单位\n";
                break;
            default:
                answer = "Unknown language pack";
                break;
        }
        return answer;
    }

    public static String PatriotMissile(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "Name: PatriotMissile\n" +
                     "Damage: 60/120/180\n" +
                     "Attack Type: bullet\n" +
                     "Damage: 120/150/200\n" +
                     "Attack Type: explosive\n" +
                     "Explosion Radius: 45\n" +
                     "Firing Rate: 56/70/84\n" +
                     "Range: 0-550\n" +
                     "Cost: 180-140/160\n" +
                     "Target Type: air\n";
                break;
            case Language.Chinese:
                answer = "名字：导弹塔\n" +
                     "伤害： 60/120/180\n" +
                     "攻击类型：子弹\n" +
                     "伤害：120/150/200\n" +
                     "攻击类型：爆炸\n" +
                     "爆炸范围：45\n" +
                     "攻击速度：56/70/84\n" +
                     "射程：0-550\n" +
                     "造价：180-140/160\n" +
                     "目标类型：空中单位\n";
                break;
            default:
                answer = "Unknown language pack";
                break;
        }
        return answer;
    }

    public static String Prisim(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "Name: Prisim\n" +
                     "Damage: 80/130/160\n" +
                     "Attack Type: tesla\n" +
                     "Firing Rate: 77\n" +
                     "Range: 0-240\n" +
                     "Cost: 135/155/165\n" +
                     "Target Type: ground\n";
                break;
            case Language.Chinese:
                answer = "名字：电击塔\n" +
                     "伤害：80/130/160\n" +
                     "攻击类型：电磁\n" +
                     "攻击速度：77\n" +
                     "射程：0-240\n" +
                     "造价：135/155/165\n" +
                     "目标类型：地面单位\n";
                break;
            default:
                answer = "Unknown language pack";
                break;
        }
        return answer;
    }

    public static String Transformer(Language l)
    {
        String answer = "";
        switch (l)
        {
            case Language.English:
                answer = "Name: Transformer\n" +
                     "Damage: 35/15/0\n" +
                     "Attack Type: tesla\n" +
                     "Slow Radius: 120\n" +
                     "Slow Effect: 0.8/0.6/0.45\n" +
                     "Slow Duration: 3s\n" +
                     "Firing Rate: 70\n" +
                     "Range: 0-240/0-270/0-300\n" +
                     "Cost: 140/160/180\n" +
                     "Target Type: ground\n";
                break;
            case Language.Chinese:
                answer = "名字：变压器\n" +
                     "伤害：35/15/0\n" +
                     "攻击类型：电磁\n" +
                     "减速半径：120\n" +
                     "减速效果：0.8/0.6/0.45\n" +
                     "持续时间：3秒\n" +
                     "攻击速度：70\n" +
                     "射程：0-240/0-260/0-280\n" +
                     "造价：140/160/180\n" +
                     "目标类型：地面单位\n";
                break;
            default:
                answer = "Unknown language pack";
                break;
        }
        return answer;
    }
}
