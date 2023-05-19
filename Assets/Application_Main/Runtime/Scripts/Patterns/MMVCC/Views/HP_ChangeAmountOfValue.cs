namespace HiscomProject.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Managers;
    
    public class HP_ChangeAmountOfValue : QuestView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected string notificationToReceive;
        [SerializeField] protected int amountToDo;
        protected int amountDone;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override bool CheckQuestStatus()
        {
            if (amountDone >= amountToDo)
            {
                IsCompleted = true;
                RemoveObservers();
                return true;
            }
            
            IsCompleted = false;
            return false;
        }
        
        protected virtual void AddObservers()
        {
            NotificationManager.Instance.AddObserver(notificationToReceive, gameObject, (_, _) => IncrementAmount());
        }
        protected virtual void RemoveObservers()
        {
            NotificationManager.Instance.RemoveObserver(gameObject);
        }

        protected virtual void IncrementAmount()
        {
            amountDone++;
        }
        
        #endregion

        #region Public Methods

        public override void StartQuest()
        {
            base.StartQuest();
            AddObservers();
        }

        #endregion
        
        #endregion
    }
}