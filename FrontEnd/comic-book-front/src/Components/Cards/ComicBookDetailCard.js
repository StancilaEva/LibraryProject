import { Button, Card, CardMedia, CssBaseline, Divider, Rating, Typography } from "@mui/material";
import { CardContent } from "@mui/material";
import { Container } from "@mui/material";
import { Box } from "@mui/system";
import { useState } from "react";
import { getComicBookReview } from "../../services/ReviewService";
import { useEffect } from "react";
import { useParams } from "react-router";
function ComicBookDetailCard(props) {
    let { id } = useParams()
    const { comicBook,refresh } = props
    const [rating, setRating] = useState(3)

    const loadRating = async () => {
        const response = await getComicBookReview(id)
        setRating(response)
    }

    useEffect(() => { loadRating() }, [refresh])
    return (
        <Card sx={{ objectFit: 'contain', height: '85vh' }}>
            <CardMedia
                component="img"
                src={comicBook.cover}
                sx={{ objectFit: 'contain', height: '65vh' }} />
            <CardContent>

                <Container>
                    <Box sx={{ display: 'flex' }}>
                        <Typography gutterBottom variant="h5" component="div" flex='75%'>
                            {comicBook.title}
                            <Rating
                                name="Rating"
                                value={rating}
                                precision={0.1}
                                readOnly
                            />
                        </Typography>

                        <Typography gutterBottom variant="h5" component="div" sx={{ justifyContent: 'right' }}>
                            {`Issue No.${comicBook.issueNumber}`}
                        </Typography>
                    </Box>
                    <Typography gutterBottom variant="h6" component="div" color="text.secondary">
                        {`Publisher: ${comicBook.publisher}`}
                    </Typography>
                    <Typography gutterBottom component="div" color="text.secondary">
                        {`Genre: ${comicBook.genre}`}
                    </Typography>
                </Container>
            </CardContent>
        </Card>
    )
}
export default ComicBookDetailCard