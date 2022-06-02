import { Bar } from 'react-chartjs-2'
import Chart from 'chart.js/auto';
import { CategoryScale } from 'chart.js';
const BarChart = (props) => {
  Chart.register(CategoryScale);
  const { mostReadGenres } = props
  var data = {
    labels: mostReadGenres ? mostReadGenres.map(obj => obj.genre) : [],
    datasets: [{
      data: mostReadGenres ? mostReadGenres.map(obj => obj.count) : [],
      backgroundColor: [
        'rgba(0, 142, 137,0.6)',
        'rgba(24, 90, 219, 0.6)',
        'rgba(255, 201, 71, 0.6)'
      ],
      borderColor: [
        'rgba(0, 142, 137,0.8)',
        'rgba(24, 90, 219, 0.8)',
        'rgba(255, 201, 71, 0.8)'
      ],
      borderWidth: 1
    }]
  };

  var options = {
    plugins: {
      legend: {
        display: false
      }
    }
  }
  return (
    <Bar
      data={data}
      options={options}
    />
  )
}
export default BarChart