//Below class is used for consuming other group API service
namespace StoreBusinessOwners
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GroceryStoreBusinessOwnerAPI
    {
        [JsonProperty("license_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LicenseId { get; set; }

        [JsonProperty("license_description")]
        public LicenseDescription LicenseDescription { get; set; }

        [JsonProperty("business_activity")]
        public string BusinessActivity { get; set; }

        [JsonProperty("legal_name")]
        public string LegalName { get; set; }

        [JsonProperty("license_status")]
        public LicenseStatus LicenseStatus { get; set; }

        [JsonProperty("zip_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ZipCode { get; set; }
    }

    public enum LicenseDescription { AutomaticAmusementDeviceOperator, CatererSLiquorLicense, ConsumptionOnPremisesIncidentalActivity, LateHour, LimitedBusinessLicense, MusicAndDance, OutdoorPatio, PackageGoods, PublicPlaceOfAmusement, RegulatedBusinessLicense, RetailFoodEstablishment, SpecialEventFood, SpecialEventLiquor, Tavern, Tobacco, TobaccoVendingIndividual };

    public enum LicenseStatus { Aac, Aai, Rev };

    public partial class GroceryStoreBusinessOwnerAPI
    {
        public static GroceryStoreBusinessOwnerAPI[] FromJson(string json) => JsonConvert.DeserializeObject<GroceryStoreBusinessOwnerAPI[]>(json, StoreBusinessOwners.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this GroceryStoreBusinessOwnerAPI[] self) => JsonConvert.SerializeObject(self, StoreBusinessOwners.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                LicenseDescriptionConverter.Singleton,
                LicenseStatusConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class LicenseDescriptionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LicenseDescription) || t == typeof(LicenseDescription?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Automatic Amusement Device Operator":
                    return LicenseDescription.AutomaticAmusementDeviceOperator;
                case "Caterer's Liquor License":
                    return LicenseDescription.CatererSLiquorLicense;
                case "Consumption on Premises - Incidental Activity":
                    return LicenseDescription.ConsumptionOnPremisesIncidentalActivity;
                case "Late Hour":
                    return LicenseDescription.LateHour;
                case "Limited Business License":
                    return LicenseDescription.LimitedBusinessLicense;
                case "Music and Dance":
                    return LicenseDescription.MusicAndDance;
                case "Outdoor Patio":
                    return LicenseDescription.OutdoorPatio;
                case "Package Goods":
                    return LicenseDescription.PackageGoods;
                case "Public Place of Amusement":
                    return LicenseDescription.PublicPlaceOfAmusement;
                case "Regulated Business License":
                    return LicenseDescription.RegulatedBusinessLicense;
                case "Retail Food Establishment":
                    return LicenseDescription.RetailFoodEstablishment;
                case "Special Event Food":
                    return LicenseDescription.SpecialEventFood;
                case "Special Event Liquor":
                    return LicenseDescription.SpecialEventLiquor;
                case "Tavern":
                    return LicenseDescription.Tavern;
                case "Tobacco":
                    return LicenseDescription.Tobacco;
                case "Tobacco Vending, Individual":
                    return LicenseDescription.TobaccoVendingIndividual;
            }
            throw new Exception("Cannot unmarshal type LicenseDescription");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LicenseDescription)untypedValue;
            switch (value)
            {
                case LicenseDescription.AutomaticAmusementDeviceOperator:
                    serializer.Serialize(writer, "Automatic Amusement Device Operator");
                    return;
                case LicenseDescription.CatererSLiquorLicense:
                    serializer.Serialize(writer, "Caterer's Liquor License");
                    return;
                case LicenseDescription.ConsumptionOnPremisesIncidentalActivity:
                    serializer.Serialize(writer, "Consumption on Premises - Incidental Activity");
                    return;
                case LicenseDescription.LateHour:
                    serializer.Serialize(writer, "Late Hour");
                    return;
                case LicenseDescription.LimitedBusinessLicense:
                    serializer.Serialize(writer, "Limited Business License");
                    return;
                case LicenseDescription.MusicAndDance:
                    serializer.Serialize(writer, "Music and Dance");
                    return;
                case LicenseDescription.OutdoorPatio:
                    serializer.Serialize(writer, "Outdoor Patio");
                    return;
                case LicenseDescription.PackageGoods:
                    serializer.Serialize(writer, "Package Goods");
                    return;
                case LicenseDescription.PublicPlaceOfAmusement:
                    serializer.Serialize(writer, "Public Place of Amusement");
                    return;
                case LicenseDescription.RegulatedBusinessLicense:
                    serializer.Serialize(writer, "Regulated Business License");
                    return;
                case LicenseDescription.RetailFoodEstablishment:
                    serializer.Serialize(writer, "Retail Food Establishment");
                    return;
                case LicenseDescription.SpecialEventFood:
                    serializer.Serialize(writer, "Special Event Food");
                    return;
                case LicenseDescription.SpecialEventLiquor:
                    serializer.Serialize(writer, "Special Event Liquor");
                    return;
                case LicenseDescription.Tavern:
                    serializer.Serialize(writer, "Tavern");
                    return;
                case LicenseDescription.Tobacco:
                    serializer.Serialize(writer, "Tobacco");
                    return;
                case LicenseDescription.TobaccoVendingIndividual:
                    serializer.Serialize(writer, "Tobacco Vending, Individual");
                    return;
            }
            throw new Exception("Cannot marshal type LicenseDescription");
        }

        public static readonly LicenseDescriptionConverter Singleton = new LicenseDescriptionConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class LicenseStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LicenseStatus) || t == typeof(LicenseStatus?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AAC":
                    return LicenseStatus.Aac;
                case "AAI":
                    return LicenseStatus.Aai;
                case "REV":
                    return LicenseStatus.Rev;
            }
            throw new Exception("Cannot unmarshal type LicenseStatus");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LicenseStatus)untypedValue;
            switch (value)
            {
                case LicenseStatus.Aac:
                    serializer.Serialize(writer, "AAC");
                    return;
                case LicenseStatus.Aai:
                    serializer.Serialize(writer, "AAI");
                    return;
                case LicenseStatus.Rev:
                    serializer.Serialize(writer, "REV");
                    return;
            }
            throw new Exception("Cannot marshal type LicenseStatus");
        }

        public static readonly LicenseStatusConverter Singleton = new LicenseStatusConverter();
    }
}
