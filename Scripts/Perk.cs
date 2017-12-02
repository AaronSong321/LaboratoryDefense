using System;
using System.Xml;
using System.Collections.Generic;
using UnityEngine;

public class Perk
{
    public enum PerkName { MM, MB, FR, TS }
    public static PerkName GetPerkName(string s)
    {
        switch(s)
        {
            case "MM": return PerkName.MM;
            case "MB": return PerkName.MB;
            case "FR": return PerkName.FR;
            case "TS": return PerkName.TS;
            default: return PerkName.MM;
        }
    }

    public static string GetString(PerkName perk)
    {
        switch(perk)
        {
            case PerkName.MM: return "MM";
            case PerkName.MB: return "MB";
            case PerkName.FR: return "FR";
            case PerkName.TS: return "TS";
            default: return "unknown perk";
        }
    }
    public static string GetChineseString(PerkName perk)
    {
        switch (perk)
        {
            case PerkName.MM: return "��ǹ��";
            case PerkName.MB: return "Ͷ����";
            case PerkName.FR: return "����";
            case PerkName.TS: return "���ר��";
            default: return "unknown perk";
        }
    }
}