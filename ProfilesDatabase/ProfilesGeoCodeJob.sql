/ *  
  
 C o p y r i g h t   ( c )   2 0 0 8 - 2 0 1 0   b y   t h e   P r e s i d e n t   a n d   F e l l o w s   o f   H a r v a r d   C o l l e g e .   A l l   r i g h t s   r e s e r v e d .     P r o f i l e s   R e s e a r c h   N e t w o r k i n g   S o f t w a r e   w a s   d e v e l o p e d   u n d e r   t h e   s u p e r v i s i o n   o f   G r i f f i n   M   W e b e r ,   M D ,   P h D . ,   a n d   H a r v a r d   C a t a l y s t :   T h e   H a r v a r d   C l i n i c a l   a n d   T r a n s l a t i o n a l   S c i e n c e   C e n t e r ,   w i t h   s u p p o r t   f r o m   t h e   N a t i o n a l   C e n t e r   f o r   R e s e a r c h   R e s o u r c e s   a n d   H a r v a r d   U n i v e r s i t y .  
  
 R e d i s t r i b u t i o n   a n d   u s e   i n   s o u r c e   a n d   b i n a r y   f o r m s ,   w i t h   o r   w i t h o u t   m o d i f i c a t i o n ,   a r e   p e r m i t t e d   p r o v i d e d   t h a t   t h e   f o l l o w i n g   c o n d i t i o n s   a r e   m e t :  
         *   R e d i s t r i b u t i o n s   o f   s o u r c e   c o d e   m u s t   r e t a i n   t h e   a b o v e   c o p y r i g h t   n o t i c e ,   t h i s   l i s t   o f   c o n d i t i o n s   a n d   t h e   f o l l o w i n g   d i s c l a i m e r .  
         *   R e d i s t r i b u t i o n s   i n   b i n a r y   f o r m   m u s t   r e p r o d u c e   t h e   a b o v e   c o p y r i g h t   n o t i c e ,   t h i s   l i s t   o f   c o n d i t i o n s   a n d   t h e   f o l l o w i n g   d i s c l a i m e r   i n   t h e   d o c u m e n t a t i o n   a n d / o r   o t h e r   m a t e r i a l s   p r o v i d e d   w i t h   t h e   d i s t r i b u t i o n .  
         *   N e i t h e r   t h e   n a m e   " H a r v a r d "   n o r   t h e   n a m e s   o f   i t s   c o n t r i b u t o r s   n o r   t h e   n a m e   " H a r v a r d   C a t a l y s t "   m a y   b e   u s e d   t o   e n d o r s e   o r   p r o m o t e   p r o d u c t s   d e r i v e d   f r o m   t h i s   s o f t w a r e   w i t h o u t   s p e c i f i c   p r i o r   w r i t t e n   p e r m i s s i o n .  
  
 T H I S   S O F T W A R E   I S   P R O V I D E D   B Y   T H E   C O P Y R I G H T   H O L D E R   ( P R E S I D E N T   A N D   F E L L O W S   O F   H A R V A R D   C O L L E G E )   A N D   C O N T R I B U T O R S   " A S   I S "   A N D   A N Y   E X P R E S S   O R   I M P L I E D   W A R R A N T I E S ,   I N C L U D I N G ,   B U T   N O T   L I M I T E D   T O ,   T H E   I M P L I E D   W A R R A N T I E S   O F   M E R C H A N T A B I L I T Y   A N D   F I T N E S S   F O R   A   P A R T I C U L A R   P U R P O S E   A R E   D I S C L A I M E D .   I N   N O   E V E N T   S H A L L   T H E   C O P Y R I G H T   H O L D E R   O R   C O N T R I B U T O R S   B E   L I A B L E   F O R   A N Y   D I R E C T ,   I N D I R E C T ,   I N C I D E N T A L ,   S P E C I A L ,   E X E M P L A R Y ,   O R   C O N S E Q U E N T I A L   D A M A G E S   ( I N C L U D I N G ,   B U T   N O T   L I M I T E D   T O ,   P R O C U R E M E N T   O F   S U B S T I T U T E   G O O D S   O R   S E R V I C E S ;   L O S S   O F   U S E ,   D A T A ,   O R   P R O F I T S ;   O R   B U S I N E S S   I N T E R R U P T I O N )   H O W E V E R   C A U S E D   A N D   O N   A N Y   T H E O R Y   O F   L I A B I L I T Y ,   W H E T H E R   I N   C O N T R A C T ,   S T R I C T   L I A B I L I T Y ,   O R   T O R T   ( I N C L U D I N G   N E G L I G E N C E   O R   O T H E R W I S E )   A R I S I N G   I N   A N Y   W A Y   O U T   O F   T H E   U S E   O F   T H I S   S O F T W A R E ,   E V E N   I F   A D V I S E D   O F   T H E   P O S S I B I L I T Y   O F   S U C H   D A M A G E .  
  
  
  
  
 * /  
 U S E   [ m s d b ]  
 G O  
 B E G I N   T R A N S A C T I O N  
 D E C L A R E   @ R e t u r n C o d e   I N T  
 S E L E C T   @ R e t u r n C o d e   =   0  
 I F   N O T   E X I S T S   ( S E L E C T   n a m e   F R O M   m s d b . d b o . s y s c a t e g o r i e s   W H E R E   n a m e = N ' [ U n c a t e g o r i z e d   ( L o c a l ) ] '   A N D   c a t e g o r y _ c l a s s = 1 )  
 B E G I N  
 E X E C   @ R e t u r n C o d e   =   m s d b . d b o . s p _ a d d _ c a t e g o r y   @ c l a s s = N ' J O B ' ,   @ t y p e = N ' L O C A L ' ,   @ n a m e = N ' [ U n c a t e g o r i z e d   ( L o c a l ) ] '  
 I F   ( @ @ E R R O R   < >   0   O R   @ R e t u r n C o d e   < >   0 )   G O T O   Q u i t W i t h R o l l b a c k  
  
 E N D  
  
 D E C L A R E   @ j o b I d   B I N A R Y ( 1 6 )  
 E X E C   @ R e t u r n C o d e   =     m s d b . d b o . s p _ a d d _ j o b   @ j o b _ n a m e = N ' P r o f i l e s G e o C o d e ' ,    
 	 	 @ e n a b l e d = 1 ,    
 	 	 @ n o t i f y _ l e v e l _ e v e n t l o g = 0 ,    
 	 	 @ n o t i f y _ l e v e l _ e m a i l = 0 ,    
 	 	 @ n o t i f y _ l e v e l _ n e t s e n d = 0 ,    
 	 	 @ n o t i f y _ l e v e l _ p a g e = 0 ,    
 	 	 @ d e l e t e _ l e v e l = 0 ,    
 	 	 @ d e s c r i p t i o n = N ' N o   d e s c r i p t i o n   a v a i l a b l e . ' ,    
 	 	 @ c a t e g o r y _ n a m e = N ' [ U n c a t e g o r i z e d   ( L o c a l ) ] ' ,    
 	 	 @ o w n e r _ l o g i n _ n a m e = N ' s a ' ,   @ j o b _ i d   =   @ j o b I d   O U T P U T  
 I F   ( @ @ E R R O R   < >   0   O R   @ R e t u r n C o d e   < >   0 )   G O T O   Q u i t W i t h R o l l b a c k  
 E X E C   @ R e t u r n C o d e   =   m s d b . d b o . s p _ a d d _ j o b s t e p   @ j o b _ i d = @ j o b I d ,   @ s t e p _ n a m e = N ' R u n   P a c k a g e ' ,    
 	 	 @ s t e p _ i d = 1 ,    
 	 	 @ c m d e x e c _ s u c c e s s _ c o d e = 0 ,    
 	 	 @ o n _ s u c c e s s _ a c t i o n = 1 ,    
 	 	 @ o n _ s u c c e s s _ s t e p _ i d = 0 ,    
 	 	 @ o n _ f a i l _ a c t i o n = 2 ,    
 	 	 @ o n _ f a i l _ s t e p _ i d = 0 ,    
 	 	 @ r e t r y _ a t t e m p t s = 0 ,    
 	 	 @ r e t r y _ i n t e r v a l = 0 ,    
 	 	 @ o s _ r u n _ p r i o r i t y = 0 ,   @ s u b s y s t e m = N ' S S I S ' ,    
 	 	 @ c o m m a n d = N ' / S Q L   " \ P r o f i l e s G e o C o d e "   / S E R V E R   Y o u r P r o f i l e s S e r v e r N a m e   / M A X C O N C U R R E N T   "   - 1   "   / C H E C K P O I N T I N G   O F F   / S E T   " \ P a c k a g e . V a r i a b l e s [ S e r v e r N a m e ] . V a l u e " ; Y o u r P r o f i l e s S e r v e r N a m e   / S E T   " \ P a c k a g e . V a r i a b l e s [ D a t a b a s e N a m e ] . V a l u e " ; Y o u r P r o f i l e s D a t a b a s e N a m e   / R E P O R T I N G   E ' ,    
 	 	 @ d a t a b a s e _ n a m e = N ' m a s t e r ' ,    
 	 	 @ f l a g s = 0  
 I F   ( @ @ E R R O R   < >   0   O R   @ R e t u r n C o d e   < >   0 )   G O T O   Q u i t W i t h R o l l b a c k  
 E X E C   @ R e t u r n C o d e   =   m s d b . d b o . s p _ u p d a t e _ j o b   @ j o b _ i d   =   @ j o b I d ,   @ s t a r t _ s t e p _ i d   =   1  
 I F   ( @ @ E R R O R   < >   0   O R   @ R e t u r n C o d e   < >   0 )   G O T O   Q u i t W i t h R o l l b a c k  
 E X E C   @ R e t u r n C o d e   =   m s d b . d b o . s p _ a d d _ j o b s e r v e r   @ j o b _ i d   =   @ j o b I d ,   @ s e r v e r _ n a m e   =   N ' ( l o c a l ) '  
 I F   ( @ @ E R R O R   < >   0   O R   @ R e t u r n C o d e   < >   0 )   G O T O   Q u i t W i t h R o l l b a c k  
 C O M M I T   T R A N S A C T I O N  
 G O T O   E n d S a v e  
 Q u i t W i t h R o l l b a c k :  
         I F   ( @ @ T R A N C O U N T   >   0 )   R O L L B A C K   T R A N S A C T I O N  
 E n d S a v e :  
 