import { Bar } from 'react-chartjs-2'
import Chart from 'chart.js/auto';
import { CategoryScale } from 'chart.js';
import { useState } from 'react';
import { useEffect } from 'react';
import { GetMostReadGenres } from '../../../services/StatsService';
const BarChart = () => {
  Chart.register(CategoryScale);

  const [mostReadGenres,setMostReadGenres] = useState([])

  const loadMostReadGenres = async () =>{
    const response = await GetMostReadGenres()
    setMostReadGenres(response)
  }

  useEffect(() => {
    loadMostReadGenres();
 }, []);


  var data = {
    labels: mostReadGenres ? mostReadGenres.map(obj => obj.genre) : [],
    datasets: [{
      data: mostReadGenres ? mostReadGenres.map(obj => obj.count) : [],
      backgroundColor: [
        'rgba(0, 142, 137,0.6)',
        'rgba(24, 90, 219, 0.6)',
        'rgba(255, 201, 71, 0.6)',
        'rgb(100, 111, 212,0.6)'
      ],
      borderColor: [
        'rgba(0, 142, 137,0.8)',
        'rgba(24, 90, 219, 0.8)',
        'rgba(255, 201, 71, 0.8)',
        'rgb(100, 111, 212,0.8)'
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