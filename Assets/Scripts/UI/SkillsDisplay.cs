using Core.Services;
using Madasski.Skills;
using UnityEngine;

namespace Madasski.UI.HUD
{
    public class SkillsDisplay : MonoBehaviour
    {
        [SerializeField] private SkillView _skillViewPrefab;

        private void Awake()
        {
            // var player = ServiceLocator.Instance.Get<PlayerCharacter>();
            // var playerSkillController = player.SkillController;
            // var playerSkills = playerSkillController.AvailableSkills;

            // foreach (var skillType in playerSkills)
            // {
            //     var skillView = Instantiate(_skillViewPrefab, transform);
            //     skillView.Icon.sprite = ServiceLocator.Instance.Get<SkillLibrary>().GetSkillIconByType(skillType);
            // }
        }
    }
}