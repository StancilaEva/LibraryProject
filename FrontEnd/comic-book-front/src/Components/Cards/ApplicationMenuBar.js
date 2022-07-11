import AppBar from '@mui/material/AppBar';
import { Box, Button } from '@mui/material';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import MenuItem from '@mui/material/MenuItem';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Menu from '@mui/material/Menu';
import HomeIcon from '@mui/icons-material/Home';
import SearchComic from './FilterInputs/SearchComic';

function ApplicationMenuBar(){
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);

    const navigate = useNavigate();

    //adauga meniul definit la menu icon
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };
   
    const onMyLendsClick = () =>{
        navigate(`/Client/Lends`)
    }

    const onMyAddressClick = () =>{
        navigate(`/Client/Address`)
    }

    const goToHome = () =>{
        navigate(`/`)
    }

    const LogOut = () =>{
        localStorage.clear()
        navigate(`/LogIn`)
    }

    const onStatsClick = () =>{
        navigate(`/Stats`)
    }

    const onFavClick = () =>{
        navigate(`/Favorites`)
    }

    return (
        <>
        <Box flexGorw={1}>
        <AppBar position='static' width={"100%"}>
                <Toolbar >
                    <IconButton
                        size="large"
                        edge="start"
                        color="inherit"
                        aria-label="menu"
                        sx={{ mr: 2 }}
                        onClick={handleClick}>
                        <MenuIcon />
                    </IconButton>
                    <HomeIcon
                      onClick={goToHome} sx={{marginRight:"24px"}}/>
                    <SearchComic sx={{width:'10%'}}/>
                    <Box flexGrow={1}/>
                    <Button onClick={LogOut} color="secondary">Log Out</Button>
                </Toolbar>
            </AppBar>
        </Box>
        <Menu
            id="basic-menu"
            anchorEl={anchorEl}
            open={open}
            onClose={handleClose}
            MenuListProps={{
                'aria-labelledby': 'basic-button',
            }}
        >
            <MenuItem onClick={onMyLendsClick}>My Lends</MenuItem>
            <MenuItem onClick={onMyAddressClick}>Address</MenuItem>
            <MenuItem onClick={onStatsClick}>Stats</MenuItem>
            <MenuItem onClick={onFavClick}>Favorites</MenuItem>
        </Menu>
        </>)
    
}

export default ApplicationMenuBar;