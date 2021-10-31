using Madasski.Skills;
using UnityEngine;

namespace Madasski.UI.HUD
{
    public class SkillsDisplay : MonoBehaviour
    {
        public SkillSO[] AllSkills;
        public SkillView SkillViewPrefab;

        // private List<SkillView> _skillViews;

        private void Awake()
        {
            //var player = ServiceLocator.Get<PlayerCharacter>();
            //var playerSkillController = player.GetComponent<SkillController>();
            //var playerSkills = playerSkillController.AvailableSkills;

            // foreach (var skillSO in AllSkills)
            // {
            //     var skillView = Instantiate(SkillViewPrefab, transform);
            //     skillView.Icon.sprite = SkillLibrary.Instance.GetSkillIconByType(skillSO.)
            // }
        }
    }
}