using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhdSurvey.Models
{
    public class FemaleMainSurvey
    {
        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Ваш возраст")]
        public int? Age { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Семейное положение")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Какой по счету у Вас брак?")]
        public int? MarriagesCount { get; set; }

        [Display(Name = "Сколько лет у Вас совместной жизни")]
        public int? MarriageAge { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Ваша родительская семья")]
        public string ParentsFamilyStatus { get; set; }

        [Display(Name = "В каком возрасте был развод родителей")]
        public int? ParentsDivorceAge { get; set; }

        [Display(Name = "Другое")]
        public string ParentsFamilyStatusOther { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Образование")]
        public string Education { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Сколько всего у Вас детей (укажите их пол и возраст)")]
        public string ChildrenAmount { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Срок беременности (в неделях)")]
        public int PregnancyAge { get; set; }


        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Была ли беременность запланированной?")]
        public string PregnancyWasPlanned { get; set; }

        [Display(Name = "Другое")]
        public string PregnancyWasPlannedOther { get; set; }

        [Display(Name = "Почему Вы решили родить ребенка?")]
        public string PregnancyMotivation { get; set; }

        [Display(Name = "Решали ли Вы вопрос о сохранении или прерывании беременности, когда узнали о ней?")]
        public string PregnancyInterruptionWasDiscussed { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Является ли для вас беременность желанной?")]
        public string PregnancyDesire { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "С чьей стороны исходила инициатива? ")]
        public string PregnancyInitiator { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Ваши первые впечатления и мысли, когда вы узнали, что беременны")]
        public string PregnancyFirstThoughts { get; set; }

        [Display(Name = "Как муж отреагировал на беременность? ")]
        public string PregnancyHusbandReactions { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Пытаетесь ли Вы представить своего будущего ребенка?")]
        public string ImaginedChildAppearence { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Придумываете ли Вы имя для ребенка?")]
        public string ImagineChildName { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Разговариваете ли Вы со своим будущим ребенком, если да, то как часто?")]
        public string TalkToChild { get; set; }

        [Display(Name = "Какой была ваша реакция, когда ребенок пошевелился в первый раз?")]
        public string ChildFirstMovementReaction { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Невыразимо приятны")]
        public string VeryPleasantFeelingsFromChildMovements { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Весьма приятны")]
        public string PleasantFeelingsFromChildMovements { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Скорее приятны, чем неприятны")]
        public string MorePleasentFeelingsFromChildMovements { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Скорее неприятны, чем приятны")]
        public string MoreUnpleasentFeelingsFromChildMovements { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Достаточно неприятны")]
        public string UnpleasentFeelingsFromChildMovements { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Болезненны")]
        public string PainfulFeelingsFromChildMovements { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Бывают не ко времени")]
        public string WrongTimeFeelingsFromChildMovements { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Мешают мне (спать, что-то делать)")]
        public string InterruptionFeelingsFromChildMovements { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Представляете ли вы качества характера или качества личности будущего ребенка")]
        public string ImaginedChildCharacter { get; set; }

        [Display(Name = "Какие качества своего будущего ребенка вы хотели бы видеть?")]
        public string ChildCharacter { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Посещаете(ли) ли вы курсы по подготовке к материнству/курсы подготовки к семейным родам?")]
        public string WifeVisitedPreparationCourses { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Как Вы думаете, какие трудности Вас ждут?")]
        public string DifficultiesExpected { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Оцените Вашу готовность к материнству (укажите по 100-бальной шкале, насколько Вы готовы  быть матерью)")]
        [Range(0, 100, ErrorMessage = "Число должно быть от 0 до 100")]
        public int MotherhoodReadiness { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Оцените Вашу удовлетворенность отношениями с супругом/партнером на данный момент: 1 – плохие, 10 - очень хорошие")]
        [Range(0, 10, ErrorMessage = "Число должно быть от 1 до 10")]
        public int RelationWithHusbandQuality { get; set; }

        [Display(Name = "Ваше эмоциональное состояние в 1-й триместр")]
        public string FirstTrimesterEmotionalStatus { get; set; }

        [Display(Name = "Другое")]
        public string FirstTrimesterEmotionalStatusOther { get; set; }

        [Display(Name = "Ваше эмоциональное состояние в 2-й триместр")]
        public string SecondTrimesterEmotionalStatus { get; set; }

        [Display(Name = "Другое")]
        public string SecondTrimesterEmotionalStatusOther { get; set; }

        [Display(Name = "Ваше эмоциональное состояние в 3-й триместр")]
        public string ThirdTrimesterEmotionalStatus { get; set; }

        [Display(Name = "Другое")]
        public string ThirdTrimesterEmotionalStatusOther { get; set; }

        [Display(Name = "Ваше физическое состояние в 1-й триместр")]
        public string FirstTrimesterPhysicalStatus { get; set; }

        [Display(Name = "Другое")]
        public string FirstTrimesterPhysicalStatusOther { get; set; }

        [Display(Name = "Ваше физическое состояние в 2-й триместр")]
        public string SecondTrimesterPhysicalStatus { get; set; }

        [Display(Name = "Другое")]
        public string SecondTrimesterPhysicalStatusOther { get; set; }

        [Display(Name = "Ваше физическое состояние в 3-й триместр")]
        public string ThirdTrimesterPhysicalStatus { get; set; }

        [Display(Name = "Другое")]
        public string ThirdTrimesterPhysicalStatusOther { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Ваше отношение к изменение своей внешности")]
        public string AppearenceChangesAttitude { get; set; }
        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Испытывали ли вы состояние эмоционального стресса?")]
        public string WasEmotionalStress { get; set; }
    }
}
