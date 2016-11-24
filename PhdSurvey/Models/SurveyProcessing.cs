﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhdSurvey.Models
{
    public class SurveyProcessing
    {
        public static Tuple<string, string> Diner(Survey survey)
        {
            string[] results = new string[]
            {
                "Люди, которые набирают столько баллов, обычно реагируют на какое-то тяжелое событие в их жизни, например, утрата близкого человека или безработица. Также подобный уровень может быть результатом злоупотребления алкоголем или наличием другой зависимости. Подобная неудовлетворенность обозначает, что у человек не доволен тем, как идут дела в большинстве его жизненных сфер: работа, учеба, личная жизнь, здоровье, финансы и т.п. Поговорите с вашим близким человеком, с психологом, с другом, возможно, вы найдете позитивные пути к улучшению ситуации.",
                "К сожалению, вы не удовлетворены вашей жизнью. Может быть, у вас во всех сферах жизни (учеба, работа, здоровье, личная жизнь и пр.) дела идут не очень хорошо, или есть одна или две сферы, где все плохо. Если подобная неудовлетворенность — это ответ на недавнее неприятное событие, такое как тяжелая утрата, развод, увольнение и т.п., помните, что через некоторое время все войдет в норму, и вы вернетесь к высокому уровню удовлетворенности. Однако, если такое состояние — хроническое, необходимо что-то менять, причем не только в жизненных оценках и подходах, но и в активности. Кроме того, такой уровень неудовлетворенности, скорее всего, приводит к низкой эффективности. Поговорите с вашим близким человеком, с психологом, с другом, возможно, вы найдете позитивные пути к улучшению ситуации.",
                "Люди, которые набирают столько баллов, как правило, имеют небольшие, но важные проблемы в разных областях своей жизни. Или же в основном у них все хорошо, но есть одна какая-то большая проблема, например, в учебе, в работе, здоровье, финансах или личной жизни. Если вы «переместились» в эту группу из верхних уровней после какого-то неприятного жизненного события, то имейте в виду, что через некоторое время всё улучшится. Однако, если вы постоянно слегка неудовлетворены вашей жизнью, то пора что-то предпринимать. Изменения в жизни — это нормально, но хроническая неудовлетворенность требует к себе внимания и размышлений.",
                "В целом, вы удовлетворены вашей жизнью, но вы хотели бы улучшить ваше положение в большинстве жизненных сфер, например, в работе, учебе или в личной жизни и финансах. Может быть, вы более чем удовлетворены во всех сферах вашей жизни, но есть какая-то одна, которая требует значительных улучшений. Вам есть, куда развиваться, это хорошо.",
                "Люди, которые набирают столько баллов, обычно вполне удовлетворены своей жизнью. Конечно, и у них есть сложности и ошибки, есть какие-то области, которые они хотели бы улучшить, но в целом они наслаждаются жизнью, и чувствуют, что в основных областях их жизни — учеба, работа, семья, финансы, развитие и здоровье — всё более-менее хорошо.",
                "Люди, которые набирают столько баллов, любят жизнь и уверены, что у них все идёт хорошо. Нельзя утверждать, что жизнь у них прекрасна и легка, но в целом они наслаждаются жизнью, и они чувствуют, что в основных областях их жизни — учеба, работа, семья, финансы, развитие и здоровье — всё более-менее хорошо."
            };

            int countScore = 0;
            List<int> answers = JsonConvert.DeserializeObject<List<int>>(survey.Answers);
            for (int i = 0; i < answers.Count; i++)
            {
                countScore += answers[i] + 1;
            }

            if (countScore == 35)
            {
                return new Tuple<string, string>("35 из 35", results[5]);
            }

            return new Tuple<string, string>(countScore + " из 35", results[countScore / 5 - 1]);
        }

        public static Tuple<string, string> Alyoshina(Survey survey)
        {
            var results = new string[] { "Низкая удволетворенность браком", "Средняя удволетворенность браком", "Высокая удволетворенность браком" };
            int countScore = 0;
            int[] forwardScale = new int[] { 1, 2, 4, 6, 9, 11, 13, 15 };
            int[] backScale = new int[] { 0, 3, 5, 7, 8, 10, 12, 14 };
            List<int> answers = JsonConvert.DeserializeObject<List<int>>(survey.Answers);
            foreach (var item in forwardScale)
            {
                countScore += answers[item];
            }
            foreach (var item in backScale)
            {
                countScore += 3 - answers[item];
            }

            if (countScore <= 18)
            {
                return new Tuple<string, string>(countScore + " из 48", results[0]);
            }
            else if (countScore <= 39)
            {
                return new Tuple<string, string>(countScore + " из 48", results[1]);
            }
            else
            {
                return new Tuple<string, string>(countScore + " из 48", results[2]);
            }
        }

        public static Tuple<string, string> Dobryakova(Survey survey)
        {
            int[] typesCount = new int[] { 0, 0, 0, 0, 0 };

            int[,] resultMatrix = new int[,]
            {
                { 2, 1, 3, 0, 4 },
                { 3, 0, 1, 2, 4 },
                { 1, 3, 0, 4, 2 },
                { 3, 4, 1, 2, 0 },
                { 0, 2, 3, 1, 4 },
                { 1, 2, 0, 4, 3 },
                { 2, 1, 0, 4, 3 },
                { 0, 2, 4, 1, 3 },
                { 4, 3, 2, 1, 0 }
            };

            List<int> answers = JsonConvert.DeserializeObject<List<int>>(survey.Answers);

            for (int i = 0; i < answers.Count; i++)
            {
                typesCount[resultMatrix[i, answers[i]]]++;
            }

            int maxValue = typesCount.Max();
            int maxIndex = typesCount.ToList().IndexOf(maxValue);

            switch (maxIndex)
            {
                case 0:
                    return new Tuple<string, string>("Оптимальный тип ПКГД", "Оптимальный тип ПКГД (психологический компонент гестационной доминанты) отмечается у женщин, ответственно, но без излишней тревоги относящихся к своей беременности. В этих случаях, как правило, отношения в семье гармоничны, беременность желанна обоими супругами. Женщина, удостоверившись, что беременна, продолжает вести активный образ жизни, но своевременно встает на учет в женскую консультацию, выполняет рекомендации врачей, следит за своим здоровьем, с удовольствием и успешно занимается на курсах дородовой подготовки.");
                case 1:
                    return new Tuple<string, string>("Гипогестогнозический тип ПКГД", "Гипогестогнозический тип ПКГД (психологический компонент гестационной доминанты) нередко встречается у женщин, не закончивших учебу, увлеченных работой, а также при нежеланной беременности. До того момента, когда не считаться с изменениями организма женщина уже не может, она старается совсем не менять ритм жизни, привычек, не думает о будущем ребенке. Обычно такие женщины испытывают сильную тревогу, но стараются скрывать её от окружающих, не замечать самой. Фон настроения при этом часто понижен, хотя возможны и его беспричинные колебания. Женщины с гипогестогнозическим типом ПКГД нередко скептически относятся курсам дородовой подготовки, пренебрегают занятиями.");
                case 2:
                    return new Tuple<string, string>("Эйфорический тип ПКГД", "Эйфорический тип ПКГД (психологический компонент гестационной доминанты) характеризуется преобладанием повышенного настроения, уверенностью в благополучном родоразрешении, легковестностью и непониманием своей новой роли сейчас и ближайшем будущем. Такой тип ПКГД отмечается у женщин с истерическими чертами личности, а также у длительно лечившийся от бесплодия. Нередко беременность становится средством манипулирования, способом изменения отношения с мужем, достижения меркантильных целей. При этом декларируется чрезмерная любовь к будущему ребенку, возникающие недомогания и трудности преувеличиваются. Женщины претенциозны, требуют от окружающих повышенного внимания, выполнения любых прихотей. Посещают врачей и курсы дородовой подготовки, но далеко не ко всем советам прислушиваются и не все рекомендации выполняют или делают это формально.");
                case 3:
                    return new Tuple<string, string>("Тревожный тип ПКГД", "Тревожный тип ПКГД (психологический компонент гестационной доминанты) характеризуется высоким уpoвнeм тревоги у беременных, что влияет на ее соматическое состояние. Тревога может быть вполне оправданной и понятной (наличие острых или хронических заболеваний, дисгармоничные отношения в семье, неудовлетворительные материально-бытовые условия и т.п.). В некоторых случаях беременная женщина либо переоценивает имеющиеся проблемы, либо не может объяснить, с чем связана тревога, которую она постоянно испытывает. Нередко тревога сопровождается ипохондричностью. Нередко неправильные действия медицинских работников способствуют повышению тревоги у женщин. Большинство из них нуждается в помощи психотерапевта.");
                case 4:
                    return new Tuple<string, string>("Депрессивный тип ПКГД", "Депрессивный тип ПКГД (психологический компонент гестационной доминанты) проявляется прежде всего резко сниженным фоном настроения у беременных. Женщина, мечтавшая о ребенке, может начать утверждать, что теперь не хочет его, не верит в свою способность выносить и родить здоровое дитя, боится умереть в родах. Женщины считают, что беременность \"изуродовала их\", боятся быть покинутыми мужем, часто плачут. В некоторых семьях подобное поведение будущей матери может действительно ухудшить ее отношения с родственниками, объясняющих все капризами, не понимающими, что женщина нездорова. Это еще больше усугубляет ее состояние. В тяжелых случаях появляются сверхценные, а иногда и бредовые инохондрические идеи, идеи самоуничижения, обнаруживаются суицидальные тенденции. ");
            }

            return new Tuple<string, string>("", "");
        }

        public static Tuple<string, string> Riff(Survey survey)
        {
            string result = "";

            int[] typesCount = new int[] { 0, 0, 0, 0, 0, 0 };
            List<int> scoresForAnswer = new List<int> { 1, 2, 3, 4, 5 };

            List<int> answers = JsonConvert.DeserializeObject<List<int>>(survey.Answers);

            typesCount[0] += scoresForAnswer[answers[0]];
            typesCount[0] += scoresForAnswer[answers[17]];
            typesCount[1] += scoresForAnswer[answers[2]];
            typesCount[2] += scoresForAnswer[answers[3]];
            typesCount[2] += scoresForAnswer[answers[6]];
            typesCount[3] += scoresForAnswer[answers[1]];
            typesCount[4] += scoresForAnswer[answers[4]];
            typesCount[4] += scoresForAnswer[answers[8]];
            typesCount[5] += scoresForAnswer[answers[5]];
            typesCount[5] += scoresForAnswer[answers[12]];

            scoresForAnswer.Reverse();

            typesCount[0] += scoresForAnswer[answers[15]];
            typesCount[1] += scoresForAnswer[answers[9]];
            typesCount[1] += scoresForAnswer[answers[13]];
            typesCount[2] += scoresForAnswer[answers[14]];
            typesCount[3] += scoresForAnswer[answers[10]];
            typesCount[3] += scoresForAnswer[answers[16]];
            typesCount[4] += scoresForAnswer[answers[11]];
            typesCount[5] += scoresForAnswer[answers[7]];

            result += "<p><b>Автономность</b> (" + typesCount[0] + " из 15): ";
            if (typesCount[0] > 10)
            {
                result += "Вам присущи самоопределение и независимость. Вы способны противостоять социальному давлению, мыслить и вести себя независимо. Вы умеете сами регулировать свое поведение. Вы оцениваете себя, исходя из личных стандартов. </p>";
            }
            else
            {
                result += "Вы часто озабочены ожиданиями и оценками других людей. При принятии важных решений Вы опираетесь на суждения других людей. Ваше мышление подвержено социальному давлению. </p>";
            }

            result += "<p><b>Компетентность</b> (" + typesCount[1] + " из 15): ";
            if (typesCount[1] >= 9)
            {
                result += "Вы обладаете чувством мастерства и компетентности средой, осуществляете разнообразные виды деятельности, а также способны вбирать или создавать подходящий контекст для реализации личных потребностей и ценностей. </p>";
            }
            else
            {
                result += "Вам трудно справляться с повседневными делами. Вы чувсвтвуете, что неспособны улучшить или изменить окружающие обстоятельства, а также не осознаёте возможности, предоставляемые окружаюзей средой. У вас отсутствует чувство контроля над внешним миром. </p>";
            }

            result += "<p><b>Личностный рост</b> (" + typesCount[2] + " из 15): ";
            if (typesCount[2] >= 9)
            {
                result += "Вы обладаете чувством продолжающегося развития и реализации своего потенциала, видите свой рост и экспансию, открыты новому опыту. Вы наблюдаете все большее совершенствование себя и своего поведения с течением времени. Изменения отражают все большее познание себя и эффективность. </p>";
            }
            else
            {
                result += "Вас не покидает чувство личной стагнации, а также отсутствует ощущение улучшения и экспансии со временем. Вам присуще чувство скуки и незаинтересованности в жизни. Вы чувствуете себя неспособным приобретать новые установки и способы поведения. </p>";
            }

            result += "<p><b>Позитивные отношения</b> (" + typesCount[3] + " из 15): ";
            if (typesCount[3] >= 9)
            {
                result += "Вы получаете удовлетворение от теплых, доверительных отношений с другими, заботитесь о благополучии других, а также способны к сильной эмпатии, привязанности и близости. Вы понимаете необходимость идти на уступки во взаимоотношениях. </p>";
            }
            else
            {
                result += "Вы испытываете недостаток близких, доверительных отношений с другими. Вам трудно заботиться о других, быть теплым и открытым. Вы изолированы и фрустрированы в межличностных отношениях. Вы не стремитесь идти на компромисс для поддержания важных связей с другими. </p>";
            }

            result += "<p><b>Жизненные цели</b> (" + typesCount[4] + " из 15): ";
            if (typesCount[4] >= 9)
            {
                result += "Вы имеете цели в жизни и чувство направленности, а также осмысленности своего прошлого и настоящего. У вас есть убеждения, придающие жизни цель. У вас есть основания и причины для того, чтобы жить. </p>";
            }
            else
            {
                result += "У вас нет чувства осмысленности жизни, а также вы испытываете недостаток целей и чувства направленности. Вы часто не видите целей и не испытываете чувства осмысленности по отношению как к своему прошлом, так и к настоящему. У вас отсутствуют воззрения и убеждения, придаюзие жизни смысл. </p>";
            }

            result += "<p><b>Самопринятие</b> (" + typesCount[5] + " из 15): ";
            if (typesCount[5] >= 9)
            {
                result += "Вы позитивно относитесь к себе и своему прошлому, осознаете и принимаете свои разные стороны, включая как положительные, так и отрицательные качества. </p>";
            }
            else
            {
                result += "Вы часто неудовлетворены собой и разочарованы своим прошлым. Вы обеспокоемы определенными личностными качествами, а также не желаете быть тем, кем являетесь. </p>";
            }

            return new Tuple<string, string>("", result);
        }

        public static Tuple<string, string> FemaleCondon(Survey survey)
        {
            int resultCount = 0;
            int[] typesCount = new int[] { 0, 0 };
            List<int> firstTypeQuestions = new List<int>() { 2, 5, 8, 9, 10, 11, 12, 14, 15, 18 };
            List<int> secondTypeQuestions = new List<int>() { 0, 1, 3, 4, 7, 13, 16, 17 };
            List<int> forwardScale = new List<int>() { 1, 3, 7, 10, 12, 13, 16 };
            List<int> answers = JsonConvert.DeserializeObject<List<int>>(survey.Answers);

            for (int i = 0; i < firstTypeQuestions.Count; i++)
            {
                if (forwardScale.IndexOf(firstTypeQuestions[i]) != -1)
                {
                    typesCount[0] += answers[i] + 1;
                }
                else
                {
                    typesCount[0] += 5 - answers[i];
                }
            }

            for (int i = 0; i < secondTypeQuestions.Count; i++)
            {
                if (forwardScale.IndexOf(secondTypeQuestions[i]) != -1)
                {
                    typesCount[1] += answers[i] + 1;
                }
                else
                {
                    typesCount[1] += 5 - answers[i];
                }
            }

            resultCount = typesCount[0] + typesCount[1];

            return new Tuple<string, string>(
                resultCount + " из 95",
                "<p>Качество привязанности: " + typesCount[0] + " из 50 </p>" +
                "<p>Время, затрачиваемое на поведение привязанности (интенсивность включения): " + typesCount[1] + " из 40</p>");
        }

        public static Tuple<string, string> MaleCondon(Survey survey)
        {
            int resultCount = 0;
            int[] typesCount = new int[] { 0, 0 };
            List<int> firstTypeQuestions = new List<int>() { 0, 1, 2, 6, 8, 10, 11, 15 };
            List<int> secondTypeQuestions = new List<int>() { 3, 4, 7, 9, 13, 14 };
            List<int> forwardScale = new List<int>() { 1, 3, 8, 9, 10, 13 };
            List<int> answers = JsonConvert.DeserializeObject<List<int>>(survey.Answers);

            for (int i = 0; i < firstTypeQuestions.Count; i++)
            {
                if (forwardScale.IndexOf(firstTypeQuestions[i]) != -1)
                {
                    typesCount[0] += answers[i] + 1;
                }
                else
                {
                    typesCount[0] += 5 - answers[i];
                }
            }

            for (int i = 0; i < secondTypeQuestions.Count; i++)
            {
                if (forwardScale.IndexOf(secondTypeQuestions[i]) != -1)
                {
                    typesCount[1] += answers[i] + 1;
                }
                else
                {
                    typesCount[1] += 5 - answers[i];
                }
            }

            resultCount = typesCount[0] + typesCount[1];

            return new Tuple<string, string>(
                resultCount + " из 80",
                "<p>Качество привязанности: " + typesCount[0] + " из 40 </p>" +
                "<p>Время, затрачиваемое на поведение привязанности (интенсивность включения): " + typesCount[1] + " из 30</p>");
        }
    }
}