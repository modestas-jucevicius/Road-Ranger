using System;

namespace Road_rangerVS.OutsideAPI
{
    [Flags]
    public enum CarStatus
    {
        NOT_STOLEN,
        STOLEN,
        STOLEN_LICENSE_PLATE,
        UNKNOWN
    }
}
