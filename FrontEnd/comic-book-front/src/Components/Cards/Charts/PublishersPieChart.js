import { Pie } from 'react-chartjs-2'
import Chart from 'chart.js/auto';
import { CategoryScale } from 'chart.js';
import { Box } from '@mui/system';
import { useState } from 'react';
import { useEffect } from 'react';
import { GetMostReadPublishers } from '../../../services/StatsService';

const PublishersPieChart = () => {
    Chart.register(CategoryScale);

    const [mostReadPublishers,setMostReadPublishers] = useState([])

    const loadMostReadPublishers = async () =>{
        const response = await GetMostReadPublishers()
        setMostReadPublishers(response)
    }
   
    useEffect(() => { 
        loadMostReadPublishers();
     }, []);

    
    var data = {
        labels: mostReadPublishers ? mostReadPublishers.map(obj => obj.publishers) : [],
        datasets: [{
            data: mostReadPublishers ? mostReadPublishers.map(obj => obj.count) : [],
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

    return (
        <Box height={"49vh"} width={"49vh"}>
            <Pie
                data={data}
                options={{ maintainAspectRatio: false }}
                height="32vh"
                widht="32vh"
            />
        </Box>

    )
}
export default PublishersPieChart