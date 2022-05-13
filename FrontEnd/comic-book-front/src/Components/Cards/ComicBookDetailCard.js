import { Button, Card, CardMedia, CssBaseline, Divider, Typography } from "@mui/material";
import { CardContent } from "@mui/material";
import { Container } from "@mui/material";
import { Box } from "@mui/system";


function ComicBookDetailCard(props) {
    const { comicBook } = props
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