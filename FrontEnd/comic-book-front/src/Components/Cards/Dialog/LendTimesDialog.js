import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import DialogTitle from '@mui/material/DialogTitle';
import Dialog from '@mui/material/Dialog';
import { Button,Box } from '@mui/material';
import { useState } from 'react';
import { getTimePeriods } from '../../../services/LendService';
import { useEffect } from 'react';

const LendTimesDialog = (props) => {
    const {id} = props
    const [lends, setLends] = useState([])

    const handleClickOpen = async () => {
        const response = await getTimePeriods(id)
        setLends(response)
      };

      useEffect(()=>{handleClickOpen()},[])

      const parseDate = (lend) =>{
        let startDate  = new Date(lend.startDate)
        let endDate  = new Date(lend.endDate)
        return( `${startDate.getDate()}/${startDate.getMonth()+1}/${startDate.getFullYear()} TO ${endDate.getDate()}/${endDate.getMonth()+1}/${endDate.getFullYear()}`)
      }

    return (
     
            <Box style={{maxHeight: '60vh', overflow: 'auto'}}>
                <List sx={{ pt: 0 }}>
                    {lends.map((lend, key) => (
                        <ListItem key={key}>
                            <ListItemText>{`${lend.username} from ${parseDate(lend)}`}</ListItemText>
                        </ListItem>
                    ))}
                </List>
                </Box>
          
    )
}

export default LendTimesDialog;