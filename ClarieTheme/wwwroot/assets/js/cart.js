function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
  }
  
  function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
  }

  $(document).ready(function() {
    $('.minus').click(function () {
        var $input = $(this).parent().find('input');
        var count = parseInt($input.val()) - 1;
        count = count < 1 ? 1 : count;
        $input.val(count);
        $input.change();
        return false;
    });
    $('.plus').click(function () {
        var $input = $(this).parent().find('input');
        $input.val(parseInt($input.val()) + 1);
        $input.change();
        return false;
    });

      $(document).on('click', '.minus', function (e) {
          e.preventDefault();
          let inputCount = $(this).next().val();
          let url = $(this).attr('href') + '/?count=' + inputCount;
          fetch(url)
              .then(res => res.text())
              .then(date => {
                  $(".basketindexcontainer").html(date);
              });
      })

      $(document).on('click', '.plus', function (e) {
          e.preventDefault();
          let inputCount = $(this).prev().val();
          let url = $(this).attr('href') + '/?count=' + inputCount;
          fetch(url)
              .then(res => res.text())
              .then(date => {
                  $(".basketindexcontainer").html(date);
              });
      })

});


$('.addbasket').click(function (e) {
    e.preventDefault();

    let url = $(this).attr('href');

    fetch(url).then(res => res.text()).then(data => {
        $('.cart').html(data);
    });
})

$(document).on('click', 'deletefrombasket', function (e) {
    e.preventDefault();

    let url = $(this).attr('href');

    fetch(url).then(res => res.text()).then(data => {
        $('.cart').html(data);
    });
})



