namespace Location.API.Utilities.Constants;

public static class ValidationResponseConstants
{

    //Country
    public const string CountryNameIsRequired = "Country name is required";
    public const string CountryNameLength = "Country name must be between 1 and 32 characters";

    //City
    public const string CityNameIsRequired = "City name is required";
    public const string CityNameLength = "City name must be between 1 and 32 characters";
    public const string CountryIdIsRequired = "Country id is required";

    //District
    public const string DistrictNameIsRequired = "District name is required";
    public const string DistrictNameLength = "District name must be between 1 and 32 characters";
    public const string CityIdIsRequired = "City id is required";

}
