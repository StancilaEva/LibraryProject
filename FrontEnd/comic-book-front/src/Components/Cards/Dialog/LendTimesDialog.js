import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import DialogTitle from '@mui/material/DialogTitle';
import Dialog from '@mui/material/Dialog';
import { Button } from '@mui/material';
import { useState } from 'react';
import { getTimePeriods } from '../../../services/LendService';

const LendTimesDialog = (props) => {
    const {id} = props
    const [lends, setLends] = useState([])
    const [open,setOpen] = useState(false)

    const handleClickOpen = async () => {
        const response = await getTimePeriods(id)
        setLends(response)
        setOpen(true);
      };
    
      const handleClose = (value) => {
        setOpen(false);
      };


      const parseDate = (lend) =>{
        let startDate  = new Date(lend.startDate)
        let endDate  = new Date(lend.endDate)
        return( `${startDate.getDate()}/${startDate.getMonth()+1}/${startDate.getFullYear()} TO ${endDate.getDate()}/${endDate.getMonth()+1}/${endDate.getFullYear()}`)
      }

    return (
        <div>
            <Button onClick={handleClickOpen} variant="contained">See Lends For This Comic</Button>
            <Dialog onClose={handleClose} open={open}>
                <DialogTitle>Other Users Borrowed This Comic On</DialogTitle>
                <List sx={{ pt: 0 }}>
                    {lends.map((lend, key) => (
                        <ListItem key={key}>
                            <ListItemText>{`${lend.username} from ${parseDate(lend)}`}</ListItemText>
                        </ListItem>
                    ))}
                </List>
            </Dialog>
        </div>
    )
}

export default LendTimesDialog;