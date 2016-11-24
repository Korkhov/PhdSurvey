using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhdSurvey.Models
{
    public class MaleMainSurvey
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
        [Display(Name = "Ваша занятость на работе в настоящий момент")]
        public string Job { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Сколько всего у Вас детей (укажите их пол и возраст)")]
        public string ChildrenAmount { get; set; }


        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Была ли беременность запланированной?")]
        public string PregnancyWasPlanned { get; set; }

        [Display(Name = "Другое")]
        public string PregnancyWasPlannedOther { get; set; }

        [Display(Name = "Почему Вы решили завести ребенка?")]
        public string PregnancyMotivation { get; set; }

        [Display(Name = "Решали ли Вы вопрос о сохранении или прерывании беременности, когда узнали о ней?")]
        public string PregnancyInterruptionWasDiscussed { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Ваши первые впечатления и мысли, когда вы узнали, что у вас будет ребенок")]
        public string PregnancyFirstThoughts { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Пытаетесь ли Вы представить своего будущего ребенка?")]
        public string ImaginedChildAppearence { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Придумываете ли Вы имя для ребенка?")]
        public string ImagineChildName { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Разговариваете ли Вы со своим будущим ребенком, если да, то как часто?")]
        public string TalkToChild { get; set; }

        [Display(Name = "Какие чувства Вы испытываете, когда чувствуете шевеление ребенка?")]
        public string ChildFirstMovementReaction { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Представляете ли вы качества характера или качества личности будущего ребенка")]
        public string ImaginedChildCharacter { get; set; }

        [Display(Name = "Какие качества своего будущего ребенка вы хотели бы видеть?")]
        public string ChildCharacter { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Посещаете(ли) ли вы курсы по подготовке к отцовству/курсы подготовки к семейным родам?")]
        public string HusbandVisitedPreparationCoureses { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Как Вы думаете, какие трудности Вас ждут?")]
        public string DifficultiesExpected { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Оцените Вашу готовность к отцовству (укажите по 100-бальной шкале, насколько Вы готовы  быть отцом)")]
        [Range(0, 100, ErrorMessage = "Число должно быть от 0 до 100")]
        public int FatherhoodReadiness { get; set; }

        [Required(ErrorMessage = Globals.RequiredErrorTemplate)]
        [Display(Name = "Оцените Вашу удовлетворенность отношениями с супругой/партнером на данный момент: 1 – плохие, 10 - очень хорошие")]
        [Range(0, 10, ErrorMessage = "Число должно быть от 1 до 10")]
        public int RelationWithWifeQuality { get; set; }
    }
}
