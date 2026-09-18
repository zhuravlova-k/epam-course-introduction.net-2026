using System;

namespace LouVuiDateCode;

public static class CountryParser
{
    public static Country[] GetCountry(string factoryLocationCode)
    {
        if (string.IsNullOrEmpty(factoryLocationCode))
        {
            throw new ArgumentNullException(nameof(factoryLocationCode));
        }

        return factoryLocationCode.ToUpperInvariant() switch
        {
            "A0" or "A1" or "A2" or "AA" or "AH" or "AN" or "AR" or "AS" or "BA" or "BJ" or
            "BU" or "DR" or "DU" or "DT" or "CO" or "CT" or "CX" or "ET" or "MB" or "MI" or
            "NO" or "RA" or "RI" or "SF" or "SL" or "SN" or "SP" or "SR" or "TJ" or "TH" or
            "TR" or "TS" or "VI" or "VX" => new[] { Country.France },

            "LP" or "OL" => new[] { Country.Germany },

            "BC" or "BO" or "CE" or "FO" or "MA" or "OB" or "RC" or "RE" or "SA" or "TD" => new[] { Country.Italy },

            "CA" or "LO" or "LB" or "LM" or "GI" => new[] { Country.Spain },

            "DI" or "FA" => new[] { Country.Switzerland },

            "FC" or "FH" or "LA" or "OS" => new[] { Country.USA },

            "FL" or "SD" => new[] { Country.France, Country.USA },
            "LW" => new[] { Country.France, Country.Spain },

            _ => throw new ArgumentException(
                $"Invalid factory location code: {factoryLocationCode}",
                nameof(factoryLocationCode))
        };
    }
}
