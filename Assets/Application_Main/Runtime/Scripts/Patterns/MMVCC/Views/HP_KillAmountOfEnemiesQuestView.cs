namespace HiscomProject.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Managers;
    
    public class HP_KillAmountOfEnemiesQuestView : QuestView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected string notificationToReceive;
        [SerializeField] protected int amountOfEnemiesToKill;
        protected int killedEnemies;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Awake()
        {
            AddObservers();
        }
        
        protected override bool CheckQuestStatus()
        {
            if (killedEnemies >= amountOfEnemiesToKill)
            {
                IsCompleted = true;
                RemoveObservers();
                return true;
            }
            
            IsCompleted = false;
            return false;
        }
        
        protected void AddObservers()
        {
            NotificationManager.Instance.AddObserver(notificationToReceive, gameObject, (_, _) => KillEnemy());
        }
        protected void RemoveObservers()
        {
            NotificationManager.Instance.RemoveObserver(gameObject);
        }

        #endregion

        #region Public Methods

        public void KillEnemy()
        {
            killedEnemies++;
        }

        #endregion

        #endregion
    }
}