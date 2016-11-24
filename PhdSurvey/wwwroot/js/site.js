$(document).ready(function () {
    $("#MaritalStatus").change(function () {
        $('#MarriagesCount').parent().parent().addClass('hidden');
        $('#MarriageAge').parent().parent().addClass('hidden');

        if (this.value == 'Замужем' || this.value == 'В гражданском браке') {
            $('#MarriagesCount').parent().parent().removeClass('hidden');
            $('#MarriageAge').parent().parent().removeClass('hidden');
        }
    });

    $("#ParentsFamilyStatus").change(function () {
        $("#ParentsDivorceAge").addClass('hidden');
        $("[for=ParentsDivorceAge]").addClass('hidden');
        $("#ParentsFamilyStatusOther").addClass('hidden');
        $("[for=ParentsFamilyStatusOther]").addClass('hidden');

        if (this.value == 'Был развод родителей') {
            $("#ParentsDivorceAge").removeClass('hidden');
            $("[for=ParentsDivorceAge]").removeClass('hidden');
        }
        if (this.value == 'Другое') {
            $("#ParentsFamilyStatusOther").removeClass('hidden');
            $("[for=ParentsFamilyStatusOther]").removeClass('hidden');
        }
    });

    $('#PregnancyWasPlanned').change(function () {
        $("#PregnancyWasPlannedOther").addClass('hidden');
        $("[for=PregnancyWasPlannedOther]").addClass('hidden');
        $('#PregnancyMotivation').parent().parent().addClass('hidden');
        $('#PregnancyInterruptionWasDiscussed').parent().parent().addClass('hidden');

        if (this.value == 'Другое') {
            $("#PregnancyWasPlannedOther").removeClass('hidden');
            $("[for=PregnancyWasPlannedOther]").removeClass('hidden');
        }
        if (this.value == 'Да') {
            $('#PregnancyMotivation').parent().parent().removeClass('hidden');
        }
        if (this.value == 'Нет') {
            $('#PregnancyInterruptionWasDiscussed').parent().parent().removeClass('hidden');
        }
    });

    $('#FirstTrimesterEmotionalStatus').change(function () {
        $("#FirstTrimesterEmotionalStatusOther").addClass('hidden');
        $("[for=FirstTrimesterEmotionalStatusOther]").addClass('hidden');

        if (this.value == 'Другое') {
            $("#FirstTrimesterEmotionalStatusOther").removeClass('hidden');
            $("[for=FirstTrimesterEmotionalStatusOther]").removeClass('hidden');
        }
    });

    $('#SecondTrimesterEmotionalStatus').change(function () {
        $("#SecondTrimesterEmotionalStatusOther").addClass('hidden');
        $("[for=SecondTrimesterEmotionalStatusOther]").addClass('hidden');

        if (this.value == 'Другое') {
            $("#SecondTrimesterEmotionalStatusOther").removeClass('hidden');
            $("[for=SecondTrimesterEmotionalStatusOther]").removeClass('hidden');
        }
    });

    $('#ThirdTrimesterEmotionalStatus').change(function () {
        $("#ThirdTrimesterEmotionalStatusOther").addClass('hidden');
        $("[for=ThirdTrimesterEmotionalStatusOther]").addClass('hidden');

        if (this.value == 'Другое') {
            $("#ThirdTrimesterEmotionalStatusOther").removeClass('hidden');
            $("[for=ThirdTrimesterEmotionalStatusOther]").removeClass('hidden');
        }
    });

    $('#FirstTrimesterPhysicalStatus').change(function () {
        $("#FirstTrimesterPhysicalStatusOther").addClass('hidden');
        $("[for=FirstTrimesterPhysicalStatusOther]").addClass('hidden');

        if (this.value == 'Другое') {
            $("#FirstTrimesterPhysicalStatusOther").removeClass('hidden');
            $("[for=FirstTrimesterPhysicalStatusOther]").removeClass('hidden');
        }
    });

    $('#SecondTrimesterPhysicalStatus').change(function () {
        $("#SecondTrimesterPhysicalStatusOther").addClass('hidden');
        $("[for=SecondTrimesterPhysicalStatusOther]").addClass('hidden');

        if (this.value == 'Другое') {
            $("#SecondTrimesterPhysicalStatusOther").removeClass('hidden');
            $("[for=SecondTrimesterPhysicalStatusOther]").removeClass('hidden');
        }
    });

    $('#ThirdTrimesterPhysicalStatus').change(function () {
        $("#ThirdTrimesterPhysicalStatusOther").addClass('hidden');
        $("[for=ThirdTrimesterPhysicalStatusOther]").addClass('hidden');

        if (this.value == 'Другое') {
            $("#ThirdTrimesterPhysicalStatusOther").removeClass('hidden');
            $("[for=ThirdTrimesterPhysicalStatusOther]").removeClass('hidden');
        }
    });

    var results = [];

    $('.qst-group[name=0]').removeClass('hidden');

    $('.ans-btn').click(function () {
        var ansNum = parseInt($(this).attr('name'));
        var qstNum = parseInt($($(this).parents()[1]).attr('name'));
        var qstCount = parseInt($('#qstCount').val());

        results[qstNum] = ansNum;

        if (qstCount - 1 == qstNum) {
            submit();
            $('#prevQstBtn').addClass('hidden');
            $('.qst-group[name=' + qstNum + ']').addClass('hidden');
            $('#loader').removeClass('hidden');
            return;
        }

        if (qstNum == 0) {
            $('#prevQstBtn').removeClass('hidden');
        }
        $('.qst-group[name=' + qstNum + ']').addClass('hidden');
        $('.qst-group[name=' + (qstNum + 1) + ']').removeClass('hidden');
    });

    $('#prevQstBtn').click(function () {
        var qstNum = parseInt($('.qst-group:not(.hidden)').attr('name'));
        if (qstNum == 1) {
            $('#prevQstBtn').addClass('hidden');
        }
        $('.qst-group[name=' + qstNum + ']').addClass('hidden');
        $('.qst-group[name=' + (qstNum - 1) + ']').removeClass('hidden');
    });

    function submit() {
        var type = $('#type').val();
        var gender = $('#gender').val();
        $.post('/User/Survey', {
            type: type,
            gender: gender,
            answers: results
        }, function () {
            window.location = '/User/Result?type=' + type + '&gender=' + gender;
        })
    }
});