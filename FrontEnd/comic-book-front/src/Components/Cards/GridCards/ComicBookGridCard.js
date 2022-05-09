
import { useNavigate } from 'react-router-dom';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea } from '@mui/material';



function ComicBookGridCard(props) {

    const { comicBook } = props
    const navigate = useNavigate()


    const onComicCardClick = async () => {
        navigate(`/ComicBook/${comicBook.id}`)
    }
    return (
        <Card sx={{ height: '100%', width: '40vh' }}>
            <CardActionArea onClick={onComicCardClick}>
                <CardMedia
                    component="img"
                    image={require(`../../../${comicBook.cover}`)}
                    sx={{ objectFit: 'contain', height: '40vh' }}
                />
                <CardContent>
                    <Typography gutterBottom component="div" alignItems={'center'}>
                        {`${comicBook.title}`}
                    </Typography>
                </CardContent>
            </CardActionArea>
        </Card>
    )

}
export default ComicBookGridCard