using System;
using UnityEngine;

namespace Madasski.Skills
{
    [Serializable]
    public class SkillData //: MonoBehaviour
    {
        [SerializeField] private SkillType _skillType;
        [SerializeField] private Sprite _icon;
        [SerializeField] private SkillSO _skillSO;

        public SkillType SkillType => _skillType;
        public Sprite Icon => _icon;
        public SkillSO SkillSO => _skillSO;
    }
}