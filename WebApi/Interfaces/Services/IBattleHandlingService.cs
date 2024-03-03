namespace WebApi.Interfaces.Services
{
    public interface IBattleHandlingService
    {
        /// <summary>
        /// Execute the battle 
        /// </summary>
        /// <param name="battle"></param>
        public void ExecuteBattle(Battle battle);
        /// <summary>
        /// Generate random heroes by number of heroes in battle
        /// </summary>
        /// <param name="battle"></param>
        public void GenerateRandomHeroesByBattle(Battle battle);
    }
}
