# ClipboardImageSaver
Automatically save image that comes from 'print screen' key to specified folder.
<p>C#Winform+WindowsAPI做个剪贴板无缝自动保存器（视频截图利器）</p>
<p>利用C#和Window API做了个自动保存剪贴板内的图片的工具，用在<strong>给视频截图</strong>上是最好不过的了。共享之。</p>
<p><a href="http://images.cnitblog.com/blog/383191/201305/03230925-ca77a1c59a364d259b0c929837b56ce9.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="clip_image001" src="http://images.cnitblog.com/blog/383191/201305/03230926-7ed0a4b7a99f495586060ba64353a9a8.png" alt="clip_image001" width="559" height="264" border="0" /></a></p>
<p>点击Start按钮，就会在剪贴板内容发生变化时自动把保存到指定位置（保存为jpg格式的图片），并且以指定的字符串作为文件的前缀，后面跟上序号。所以这个工具是和PrtSc截屏键紧密结合使用的，按一次PrtSc，就保存一张图片。就算一直按着不放，也能把每个截屏命令都执行到。</p>
<p>另外，Distinct按钮可以把Path文件夹所在的所有文件检查一遍，自动删掉内容完全一样的文件。这个很实用吧。</p>
<p>源码在此：<a href="http://files.cnblogs.com/bitzhuwei/bitzhuwei.Clipboard.Winform.zip" target="_blank">http://files.cnblogs.com/bitzhuwei/bitzhuwei.Clipboard.Winform.zip</a></p>
<p>release版程序在此：<a href="http://files.cnblogs.com/bitzhuwei/bitzhuwei.Clipboard.Winform-release.zip" target="_blank">http://files.cnblogs.com/bitzhuwei/bitzhuwei.Clipboard.Winform-release.zip</a></p>
<h3>1. 将剪贴板内的图片保存到文件</h3>
<p>代码如下。</p>
<div id="codeSnippetWrapper" style="text-align: left; line-height: 12pt; background-color: #f4f4f4; margin: 20px 0px 10px; width: 97.5%; font-family: 'Courier New', courier, monospace; direction: ltr; max-height: 200px; font-size: 8pt; overflow: auto; cursor: text; border: silver 1px solid; padding: 4px;">
<div id="codeSnippet" style="text-align: left; line-height: 12pt; background-color: #f4f4f4; width: 100%; font-family: 'Courier New', courier, monospace; direction: ltr; color: black; font-size: 8pt; overflow: visible; border-style: none; padding: 0px;">
<pre><span id="lnum1" style="color: #606060;">   1:</span> <span style="color: #0000ff;">void</span> SaveClipboardImage()</pre>
<!--CRLF-->
<pre><span id="lnum2" style="color: #606060;">   2:</span> {</pre>
<!--CRLF-->
<pre><span id="lnum3" style="color: #606060;">   3:</span>     var data = System.Windows.Forms.Clipboard.GetDataObject();</pre>
<!--CRLF-->
<pre><span id="lnum4" style="color: #606060;">   4:</span>     var bmap = (Image)(data.GetData(<span style="color: #0000ff;">typeof</span>(System.Drawing.Bitmap)));</pre>
<!--CRLF-->
<pre><span id="lnum5" style="color: #606060;">   5:</span>     <span style="color: #0000ff;">if</span> (bmap != <span style="color: #0000ff;">null</span>)</pre>
<!--CRLF-->
<pre><span id="lnum6" style="color: #606060;">   6:</span>     {</pre>
<!--CRLF-->
<pre><span id="lnum7" style="color: #606060;">   7:</span>         bmap.Save(<span style="color: #006080;">"bitzhuwei.cnblogs.com.jpg"</span>, System.Drawing.Imaging.ImageFormat.Jpeg);</pre>
<!--CRLF-->
<pre><span id="lnum8" style="color: #606060;">   8:</span>         bmap.Dispose();</pre>
<!--CRLF-->
<pre><span id="lnum9" style="color: #606060;">   9:</span>     }</pre>
<!--CRLF-->
<pre><span id="lnum10" style="color: #606060;">  10:</span> }</pre>
<!--CRLF--></div>
</div>
<h3>2. 监听剪贴板变化的事件</h3>
<p>override掉主窗体的WndProc事件，这样就能够实现<strong>当且仅当</strong>剪贴板内容发生变化时执行一次保存动作了。</p>
<div class="cnblogs_code"><img id="Code_Closed_Image_385177" onclick="this.style.display='none'; document.getElementById('Code_Closed_Text_385177').style.display='none'; document.getElementById('Code_Open_Image_385177').style.display='inline'; document.getElementById('Code_Open_Text_385177').style.display='inline';" src="http://www.cnblogs.com/Images/OutliningIndicators/ContractedBlock.gif" alt="" width="11" height="16" align="top" /><img id="Code_Open_Image_385177" style="display: none;" onclick="this.style.display='none'; document.getElementById('Code_Open_Text_385177').style.display='none'; getElementById('Code_Closed_Image_385177').style.display='inline'; getElementById('Code_Closed_Text_385177').style.display='inline';" src="http://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockStart.gif" alt="" width="11" height="16" align="top" />
<pre><span id="Code_Closed_Text_385177" class="cnblogs_code_Collapse">override掉在主窗口的WindProc事件</span><span id="Code_Open_Text_385177" style="display: none;">        <span style="color: #0000ff;">const</span> <span style="color: #0000ff;">int</span> WM_DRAWCLIPBOARD = 0x308;
        <span style="color: #0000ff;">const</span> <span style="color: #0000ff;">int</span> WM_CHANGECBCHAIN = 0x030D;
        <span style="color: #0000ff;">protected</span> <span style="color: #0000ff;">override</span> <span style="color: #0000ff;">void</span> WndProc(<span style="color: #0000ff;">ref</span> Message m)
        {
            <span style="color: #0000ff;">if</span> (nextClipboardViewer == <span style="color: #0000ff;">null</span>)
                nextClipboardViewer = (IntPtr)SetClipboardViewer((<span style="color: #0000ff;">int</span>)<span style="color: #0000ff;">this</span>.Handle);
            <span style="color: #0000ff;">switch</span> (m.Msg)
            {
                <span style="color: #0000ff;">case</span> WM_CHANGECBCHAIN:
                    <span style="color: #0000ff;">if</span> (m.WParam == nextClipboardViewer) { nextClipboardViewer = m.LParam; }
                    <span style="color: #0000ff;">else</span> { SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam); }
                    <span style="color: #0000ff;">break</span>;
                <span style="color: #0000ff;">case</span> WM_DRAWCLIPBOARD:
                    SaveClipboardImage();
                    <span style="color: #008000;">//将WM_DRAWCLIPBOARD 消息传递到下一个观察链中的窗口</span>
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    <span style="color: #008000;">//将WM_DRAWCLIPBOARD 消息传递到下一个观察链中的窗口 </span>
                    <span style="color: #0000ff;">break</span>;
                <span style="color: #0000ff;">default</span>:
                    <span style="color: #0000ff;">base</span>.WndProc(<span style="color: #0000ff;">ref</span> m);
                    <span style="color: #0000ff;">break</span>;
            }
        }</span></pre>
</div>
<p>&nbsp;</p>
<h3>3. 文件雷同判别</h3>
<p>用文件流一个字节一个字节的判断即可。大部分不同的文件，判断不了多少次就会出现字节不一样了，所以我对这个方法的效率还是有信心的。自己也试验过，对视频截图得到的1000多张图片（全屏的截图1280*800的图片），2分钟就把重复的文件都删掉了。</p>
<div class="cnblogs_code"><img id="Code_Closed_Image_584435" onclick="this.style.display='none'; document.getElementById('Code_Closed_Text_584435').style.display='none'; document.getElementById('Code_Open_Image_584435').style.display='inline'; document.getElementById('Code_Open_Text_584435').style.display='inline';" src="http://www.cnblogs.com/Images/OutliningIndicators/ContractedBlock.gif" alt="" width="11" height="16" align="top" /><img id="Code_Open_Image_584435" style="display: none;" onclick="this.style.display='none'; document.getElementById('Code_Open_Text_584435').style.display='none'; getElementById('Code_Closed_Image_584435').style.display='inline'; getElementById('Code_Closed_Text_584435').style.display='inline';" src="http://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockStart.gif" alt="" width="11" height="16" align="top" />
<pre><span id="Code_Closed_Text_584435" class="cnblogs_code_Collapse">删掉指定文件夹下所有内容相同的冗余文件</span><span id="Code_Open_Text_584435" style="display: none;">        <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">void</span> DeleteRedundancyFiles(<span style="color: #0000ff;">string</span> directory)
        {
            var files = (<span style="color: #0000ff;">new</span> DirectoryInfo(directory)).GetFiles("<span style="color: #8b0000;">*.jpg</span>");
            <span style="color: #0000ff;">for</span> (<span style="color: #0000ff;">int</span> i = 0; i &lt; files.Length; i++)
            {
                <span style="color: #0000ff;">for</span> (<span style="color: #0000ff;">int</span> j = i + 1; j &lt; files.Length; j++)
                {
                    <span style="color: #0000ff;">if</span> (File.Exists(files[i].FullName) &amp;&amp; File.Exists(files[j].FullName))
                    {
                        <span style="color: #0000ff;">bool</span> removeJ = IsSameContent(files, i, j);
                        <span style="color: #0000ff;">if</span> (removeJ)
                        {
                            <span style="color: #0000ff;">try</span>
                            {
                                File.Delete(files[j].FullName);
                            }
                            <span style="color: #0000ff;">catch</span> (Exception)
                            { }
                        }
                    }
                }
            }
        }


        <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">bool</span> IsSameContent(FileInfo[] files, <span style="color: #0000ff;">int</span> i, <span style="color: #0000ff;">int</span> j)
        {
            var result = <span style="color: #0000ff;">true</span>;
            <span style="color: #0000ff;">using</span> (FileStream fsi = <span style="color: #0000ff;">new</span> FileStream(files[i].FullName, FileMode.Open))
            {
                <span style="color: #0000ff;">using</span> (FileStream fsj = <span style="color: #0000ff;">new</span> FileStream(files[j].FullName, FileMode.Open))
                {
                    var counti = 0;
                    var countj = 0;
                    <span style="color: #0000ff;">do</span>
                    {
                        <span style="color: #0000ff;">const</span> <span style="color: #0000ff;">int</span> length = 100;
                        var bytesi = <span style="color: #0000ff;">new</span> <span style="color: #0000ff;">byte</span>[length];
                        var bytesj = <span style="color: #0000ff;">new</span> <span style="color: #0000ff;">byte</span>[length];
                        counti = fsi.Read(bytesi, 0, length);
                        countj = fsj.Read(bytesj, 0, length);
                        <span style="color: #0000ff;">if</span> (counti != countj)
                        {
                            result = <span style="color: #0000ff;">false</span>;
                        }
                        <span style="color: #0000ff;">else</span>
                        {
                            <span style="color: #0000ff;">for</span> (<span style="color: #0000ff;">int</span> k = 0; k &lt; counti; k++)
                            {
                                <span style="color: #0000ff;">if</span> (bytesi[k] != bytesj[k])
                                {
                                    result = <span style="color: #0000ff;">false</span>;
                                    <span style="color: #0000ff;">break</span>;
                                }
                            }
                        }
                    } <span style="color: #0000ff;">while</span> (result &amp;&amp; counti &gt; 0 &amp;&amp; countj &gt; 0);
                }
            }
            <span style="color: #0000ff;">return</span> result;
        }
</span></pre>
</div>
