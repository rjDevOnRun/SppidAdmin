using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SppidAdminGlobals
{
    public class Enums
    {

        public enum DatabaseType
        {
            Oracle = 0,
            SqlServer = 1,
            Sqlite = 2
        }

        public enum ItemType
        {
            ConnectorVertex = 1,
            Note = 2,
            PipeRun = 4,
            SignalRun = 5,
            InstrLoop = 6,
            InlineComp = 7,
            Representation = 8,
            Connector = 9,
            InstrFailMode = 10,
            LabelPersist = 11,
            Symbol = 12,
            InstrFunction = 14,
            Equipment = 15,
            InstrOption = 16,
            SignalPoint = 17,
            Nozzle = 20,
            ModelItem = 21,
            CaseProcess = 23,
            Source = 24,
            PlantItem = 26,
            History = 27,
            PipingPoint = 28,
            CaseControl = 31,
            PipingComp = 32,
            Mechanical = 33,
            Location = 34,
            Exchanger = 35,
            OPC = 36,
            Instrument = 37,
            Case = 38,
            Status = 39,
            BoundedShape = 41,
            PlantItemGroup = 42,
            LeaderVertex = 43,
            Label = 44,
            PlantItemGroupJoin = 47,
            RuleReference = 49,
            Relationship = 50,
            Inconsistency = 51,
            OptionFormat = 52,
            OptionAutoGap = 53,
            OptionHeatTrace = 55,
            OptionSymbology = 56,
            EquipmentOther = 57,
            Vessel = 58,
            PlantItemGroupOther = 59,
            SafetyClass = 60,
            System = 61,
            EquipComponent = 62,
            AreaBreak = 64,
            AreaBreakAttribute = 73,
            BoundedShapeVertex = 74,
            OptionSetting = 95,
            Drawing = 99,
            ItemNote = 101,
            Package = 121,
            Task = 122,
            TaskItemProperty = 123,
            GlobalDrawing = 150,
            DrawingProject = 151,
            DrawingVersion = 152,
            ModelItemClaim = 153,
            Pipeline = 154,
            ModelItemClaimOffline = 155,
            ModelItemClaimRep = 156,
            ModelItemLookup = 157,
            RepresentationLookup = 158,
            LlamaModification = 159,
            OptionDispSetFolder = 160,
            OptionDispSet = 161,
            PropertyBreak = 162,
            SmartFrame = 163,
            SmartFrameStorage = 164,
            HydraulicCircuit = 165,
            Revision = 166,
            DuctRun = 168,
            DuctingPoint = 169,
            DuctingComp = 170,
            Room = 171,
            RoomComponent = 172

        }
    }
}
