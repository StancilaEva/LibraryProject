import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea } from '@mui/material';
import { useNavigate } from 'react-router-dom';



function LendCard(props) {

  const { lend } = props
  const navigate = useNavigate()


  const onLendCardClick = async () => {
    navigate(`/Lends/${lend.lendId}`)
  }

  const parseDate = () =>{
    let startDate  = new Date(lend.startDate)
    let endDate  = new Date(lend.endDate)
    return( `${startDate.getDate()}/${startDate.getMonth()+1}/${startDate.getFullYear()} TO ${endDate.getDate()}/${endDate.getMonth()+1}/${endDate.getFullYear()}`)
  }


  return (
    <Card sx={{ height: '100%', width: '40vh' }}>
      <CardActionArea onClick={onLendCardClick}>
        <CardMedia
          component="img"
          image={require(`../../../${lend.comicBookCover}`)}
          sx={{ objectFit: 'contain', height: '40vh' }}
        />
        <CardContent>
          <Typography component="div" >
            Borrowed on:
          </Typography>
          <Typography gutterBottom component="div" >
            {parseDate()}
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  )
}
export default LendCard