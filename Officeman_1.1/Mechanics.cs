using Officeman_1._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace OfficeMan_1._1
{
    class Mechanics
    {
        public enum character { stand, jumping, falling };
        public enum game { bird, birds, pause, intersection, end };
        Hashtable CharacterState = new Hashtable();
        Hashtable GameState = new Hashtable();
        char direction;
        
        public Mechanics()
        {
            CharacterState.Add(character.stand, true);
            CharacterState.Add(character.jumping, false);
            CharacterState.Add(character.falling, false);
            GameState.Add(game.bird, false);
            GameState.Add(game.birds, false);
            GameState.Add(game.pause, false);
            GameState.Add(game.intersection, false);
            GameState.Add(game.end, false);
            direction = 'r';
        }

        public Mechanics(Mechanics obj)
        {
            this.direction = obj.direction;
            foreach (DictionaryEntry kvp in obj.GameState)
                this.GameState.Add(kvp.Key, kvp.Value);
            foreach (DictionaryEntry kvp in CharacterState)
                this.CharacterState.Add(kvp.Key, kvp.Value);
        }

        public bool this[game state]
        {
            get
            {
                foreach (DictionaryEntry kvp in GameState)
                    if ((game)kvp.Key == state)
                        return (bool)kvp.Value;
                return false;
            }
            set { GameState[state] = value; }
        }

        public bool this[character state]
        {
            get
            {
                foreach (DictionaryEntry kvp in CharacterState)
                    if ((character)kvp.Key == state)
                        return (bool)kvp.Value;
                return false;
            }
            set { CharacterState[state] = value; }
        }

        public void PegionFly(ref Rectangle PegionPlace)
        {
            PegionPlace.X -= 20;
            PegionPlace.Y -= 20;
        }

        public void TurnLeft(ref Rectangle CharacterPlace)
        {
            if (CharacterPlace.X > 25)
                CharacterPlace.X -= 20;
            if (this[character.falling] & direction == 'r')
                if (this[character.falling])
                    Sources.RotateCharacterPictures();
            direction = 'l';
        }

        public void TurnRight(ref Rectangle CharacterPlace)
        {
            if (CharacterPlace.X < 390)
                CharacterPlace.X += 20;
            if (this[character.falling] & direction == 'l')
                if (this[character.falling])
                    Sources.RotateCharacterPictures();
            direction = 'r';
        }
        public void TurnUp(ref Rectangle CharacterPlace)
        {
            if (CharacterPlace.Y > 30)
                CharacterPlace.Y -= 20;
        }

        public void TurnDown(ref Rectangle CharacterPlace)
        {
            if (CharacterPlace.Y < 390)
                CharacterPlace.Y += 20;
        }
    }
}
