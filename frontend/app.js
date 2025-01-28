const apiUrl = 'http://localhost:5043/api/WeatherForecast';

async function fetchWeather() {
    try {
        const response = await fetch(apiUrl);
        const data = await response.json();
        console.log(data);

        const content = document.getElementById('content');
        content.innerHTML = data.map(item => `
            <div>
                <h2>${item.date}</h2>
                <p>Temperature: ${item.temperatureC}°C (${item.temperatureF}°F)</p>
                <p>${item.summary}</p>
            </div>
        `).join('');
    } catch (error) {
        console.error('Error fetching weather data:', error);
    }
}

fetchWeather();
