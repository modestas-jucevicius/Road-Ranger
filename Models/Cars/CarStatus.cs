using System;

namespace Models.Cars
{
    [Flags]
    public enum CarStatus {
        NOT_STOLEN = 1,
        STOLEN = 2,
        STOLEN_PLATE = 4,
        UNKNOWN = 8
    }
}
