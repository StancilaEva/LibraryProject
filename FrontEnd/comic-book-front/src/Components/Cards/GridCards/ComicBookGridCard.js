
import { useNavigate } from 'react-router-dom';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea, Chip } from '@mui/material';
import { getRole } from '../../../functions/ExtractFromToken';
import ClearIcon from '@mui/icons-material/Clear';
import { deleteComicFromList } from '../../../services/ComicBooksService';


function ComicBookGridCard(props) {

    const { comicBook,deleteComic,setDeleteComic } = props
    const navigate = useNavigate()

    const deleteComicBook = async () =>{
        const result = await deleteComicFromList(comicBook.id)
        if(result.status===200){
            setDeleteComic(deleteComic+1)
        
        }
        else if(result.status===401 || result.status===403){
            navigate('/LogIn')
        }
    }

    const onComicCardClick = async () => {
        navigate(`/ComicBook/${comicBook.id}`)
    }
    return (
        <Card sx={{ width: '40vh' }}>
            {getRole(localStorage.getItem("token")) === "Admin" && deleteComic!=undefined ?<ClearIcon onClick={deleteComicBook} sx={{color:"#ff6347"}}></ClearIcon> : <></>}
            <CardActionArea onClick={onComicCardClick}>
                <CardMedia
                    component="img"
                    src={comicBook.cover}
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