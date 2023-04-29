using System.Text.Json.Serialization;

namespace ChandyMisraAssignment
{
    public class DeadlockDetectionInput
    {
        [JsonPropertyName("graph")]
        public List<List<int>> Graph { get; set; }

        [JsonPropertyName("numProcesses")]
        public int NumProcesses { get; set; }
    }
}