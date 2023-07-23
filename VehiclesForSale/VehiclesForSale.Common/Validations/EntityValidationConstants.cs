﻿namespace VehiclesForSale.Common.Validations
{
    public static class EntityValidationConstants
    {
        public static class VehicleValidations
        {
            public const int TitleMaxLength = 60;
        }

        public static class MakeValidations
        {
            public const int NameMaxLength = 100;
        }

        public static class ModelValidations
        {
            public const int NameMaxLength = 100;
        }

        public static class TypesValidations
        {
            public const int FuelMaxLength = 50;
            public const int ImageUrlMaxLength = 2048;
            public const int TransmissionMaxLength = 20;
            public const int ColorMaxLength = 25;
            public const int CategoryMaxLength = 30;
        }
        public static class ExtrasValidations
        {
            public const int NameMaxLength = 255;
        }

        public static class UserValidations
        {
            public const int UserNameMaxLength = 20;
            public const int UserNameMinLength = 5;

            public const int UserEmailMaxLength = 60;
            public const int UserEmailMinLength = 10;

            public const int UserPassMaxLength = 20;
            public const int UserPassMinLength = 5;

        }
    }
}
