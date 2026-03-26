// Inicializamos la gráfica
const ctx = document.getElementById('conversionChart').getContext('2d');
let conversionChart = new Chart(ctx, {
  type: 'line',
  data: {
    labels: [],
    datasets: [{
      label: 'Monto convertido',
      data: [],
      borderColor: 'rgba(46, 204, 113, 1)',
      backgroundColor: 'rgba(46, 204, 113, 0.2)',
      fill: true,
      tension: 0.3
    }]
  },
  options: {
    responsive: true,
    plugins: {
      legend: { position: 'top' },
      tooltip: { mode: 'index', intersect: false }
    },
    scales: {
      y: { beginAtZero: true }
    }
  }
});

// Función de conversión
document.getElementById('convertButton').addEventListener('click', async function() {
  const API_KEY = 'f8b9ca5879111e54f4a3368c';
  const amount = parseFloat(document.getElementById('amount').value);
  const currencyFrom = document.getElementById('currencyFrom').value;
  const currencyTo = document.getElementById('currencyTo').value;
  const resultDiv = $("#result");

  // Animación del botón
  $("#convertButton").slideUp(300).delay(300).fadeIn(300);

  if (!amount || isNaN(amount)) {
    resultDiv.text('Por favor, ingresa un valor válido').fadeIn(400);
    return;
  }

  const API_URL = `https://v6.exchangerate-api.com/v6/${API_KEY}/latest/${currencyFrom}`;

  try {
    const response = await fetch(API_URL);
    const data = await response.json();

    if (data.result === 'success') {
      const rate = data.conversion_rates[currencyTo];
      const convertedAmount = (amount * rate).toFixed(2);

      // Mostrar resultado con fade
      resultDiv.hide().text(`${amount} ${currencyFrom} = ${convertedAmount} ${currencyTo}`).fadeIn(600);

      // Actualizar gráfica
      const timestamp = new Date().toLocaleTimeString();
      conversionChart.data.labels.push(timestamp);
      conversionChart.data.datasets[0].data.push(convertedAmount);
      conversionChart.update();

      // Agregar al historial
      const newItem = $(`<li>${amount} ${currencyFrom} = ${convertedAmount} ${currencyTo}</li>`);
      $("#history").prepend(newItem);
      newItem.slideDown(500);

    } else {
      resultDiv.hide().text('Error al obtener las tasas de cambio.').fadeIn(600);
    }
  } catch (error) {
    resultDiv.hide().text('Error al conectar con la API.').fadeIn(600);
  }
});

// Botón Reset: limpia gráfica, historial y resultado
$("#resetButton").click(function() {
  $("#result").fadeOut(300, function() { $(this).text("").show(); });
  
  conversionChart.data.labels = [];
  conversionChart.data.datasets[0].data = [];
  conversionChart.update();

  $("#history li").slideUp(300, function() { $(this).remove(); });
});

// Resaltar inputs al focus
$(".input-amount, .select").focus(function() {
  $(this).css("border-color", "#3498db");
}).blur(function() {
  $(this).css("border-color", "#ddd");
});