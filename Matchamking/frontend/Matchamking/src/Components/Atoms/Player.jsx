import React from 'react'
import styled from 'styled-components'
import StyledBox from './BoxStyle'

const PlayerBox = styled(StyledBox)`
    display: flex;
    cursor: pointer;
    height: 50px;
    font-size: 16px;
    padding-top: 0.5rem;
    padding-bottom: 0.5rem;
`

const Winrate = styled.div`
   text-align: left;
    width: 25%;
`

const PlayerName = styled.div`
    text-align: left;
    width: 50%;
`

const Add = styled.div`
   text-align: right;
    width: 25%;
`

const Player = ({winrate, playername, players, setPlayers}) => {

    function addPlayer()
    {
        var playerslist = []
        if (players.lenght === 0)
        {
            playerslist = players
        }
        else 
        {
            playerslist.push(players)
        }
        return setPlayers(playerslist.push(playername))
    }

    return (
    <PlayerBox>
        <Winrate>{winrate}</Winrate>
        <PlayerName>{playername}</PlayerName>
        <Add onClick={() => {
             var playerslist = players
             playerslist.push(playername)
             return setPlayers(playerslist)
            }
        }>Añadir</Add>
    </PlayerBox>
  )
}

export default Player